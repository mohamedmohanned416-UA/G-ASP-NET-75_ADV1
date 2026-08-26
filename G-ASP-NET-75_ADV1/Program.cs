using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace G_ASP_NET_75_ADV1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region q1
            //   A generic class is a class that works with different data types using a type parameter(<T>). Generics provide code reusability, type safety, better performance, and eliminate the need for casting.

            #endregion

            #region q2
          public class Container<T>
        {
            private T item;

            public void Add(T value)
            {
                item = value;
            }

            public T Get()
            {
                return item;
            }
        }
        #endregion


           
            #region q3
        public class Pair<TKey, TValue>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }

            public Pair(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }
        #endregion

            #region q4
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        #endregion


            #region q5
        public static T FindMax<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
        #endregion


            #region q6
        //  A generic interface defines operations that work with any data type.
        public interface IRepository<T>
        {
            void Add(T item);
            T Get(int id);
        }
        #endregion


            #region q7
        // The struct constraint restricts the type parameter to value types.
        public class Test<T> where T : struct
        {
            public T Value;
        }
        #endregion

        
             #region q8
        //The class constraint restricts the type parameter to reference types.
        public class Test<T> where T : class
        {
            public T Value;
        }
        #endregion

        #region q9

        //The new () constraint requires the type parameter to have a parameterless constructor.

        public class Factory<T> where T : new()
        {
            public T Create()
            {
                return new T();
            }
        }
        #endregion


        #region q10
        //The interface constraint requires the type parameter to implement a specific interface.

        public class Test<T> where T : IDisposable
        {
            public void Close(T obj)
            {
                obj.Dispose();
            }
        }
        #endregion

        #region q11
        //The base class constraint requires the type parameter to inherit from a specific base class.
        public class Animal
        {
        }

        public class Test<T> where T : Animal
        {
        }
        #endregion


        #region q12
        public class Test<T> where T : Animal, IDisposable, new()
        {
            public T Create()
            {
                return new T();
            }
        }
        #endregion


        #region q13
        //The default keyword returns the default value of the generic type.For value types, it returns 0 or false; for reference types, it returns null.

        T value = default(T);
        #endregion


        #region q14
		using System.Collections.Generic;

public class SafeList<T>
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public T Get(int index)
        {
            if (index >= 0 && index < items.Count)
                return items[index];

            return default(T);
        }
    }
    #endregion



    #region q15
    //Covariance allows a more derived type to be used where a base type is expected.The out keyword is used for output type parameters.
    public interface IRepository<out T>
    {
        T Get();
    }
    #endregion

    #region q16
    //Contravariance allows a base type to be used where a derived type is expected.The in keyword is used for input type parameters.

    public interface IProcessor<in T>
    {
        void Process(T item);
    }
    #endregion

    #region q17
    //Covariance(out) : Used for return values(output).
    //Contravariance(in) : Used for method parameters(input). 
    #endregion


    #region q18
    public class Counter<T>
    {
        public static int Count;
    }




    #endregion



    #region q19
    public class Base<T>
    {
        public T Value;
    }

    public class Derived<T> : Base<T>
    {
    } 
    #endregion


   #region q20
		 using System;
using System.Collections.Generic;

public class Cache<TKey, TValue>
    {
        private class CacheItem
        {
            public TValue Value;
            public DateTime Expiration;
        }

        private Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();

        public void Add(TKey key, TValue value, TimeSpan duration)
        {
            cache[key] = new CacheItem
            {
                Value = value,
                Expiration = DateTime.Now.Add(duration)
            };
        }

        public TValue Get(TKey key)
        {
            if (Contains(key))
                return cache[key].Value;

            return default(TValue);
        }

        public bool Contains(TKey key)
        {
            return cache.ContainsKey(key) &&
                   cache[key].Expiration > DateTime.Now;
        }

        public void Remove(TKey key)
        {
            cache.Remove(key);
        }
    }

} 
	#endregion
    }
    
}
