    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    
    namespace CacheAndFactory
    {
        class Program
        {
            private static int _iterations = 1000;
    
            static void Main(string[] args)
            {
                var factory = new ServiceFactory();
                
                // Exercise the factory which implements IServiceSource
                AccessAbcTwoTimesEach(factory);
    
                // Exercise the generics cache which also implements IServiceSource
                var cache1 = new GenericTypeServiceCache(factory);
                AccessAbcTwoTimesEach(cache1);
    
                // Exercise the collection based cache which also implements IServiceSource
                var cache2 = new CollectionBasedServiceCache(factory);
                AccessAbcTwoTimesEach(cache2);
    
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
    
            public static void AccessAbcTwoTimesEach(IServiceSource source)
            {
                Console.WriteLine("Excercise " + source.GetType().Name);
    
                Console.WriteLine("1st pass - Get an instance of A, B, and C through the source and access the DoSomething for each.");
                source.GetService<A>().DoSomething();
                source.GetService<B>().DoSomething();
                source.GetService<C>().DoSomething();
                Console.WriteLine();
    
                Console.WriteLine("2nd pass - Get an instance of A, B, and C through the source and access the DoSomething for each.");
                source.GetService<A>().DoSomething();
                source.GetService<B>().DoSomething();
                source.GetService<C>().DoSomething();
                Console.WriteLine();
    
                var clock = Stopwatch.StartNew();
    
                for (int i = 0; i < _iterations; i++)
                {
                    source.GetService<A>();
                    source.GetService<B>();
                    source.GetService<C>();
                }
    
                clock.Stop();
    
                Console.WriteLine("Accessed A, B, and C " + _iterations + " times each in " + clock.ElapsedMilliseconds + "ms through " + source.GetType().Name + ".");
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    
        public interface IService
        {
        }
    
        class A : IService
        {
            public void DoSomething() { Console.WriteLine("A.DoSomething(), HashCode: " + this.GetHashCode()); }
        }
    
        class B : IService
        {
            public void DoSomething() { Console.WriteLine("B.DoSomething(), HashCode: " + this.GetHashCode()); }
        }
    
        class C : IService
        {
            public void DoSomething() { Console.WriteLine("C.DoSomething(), HashCode: " + this.GetHashCode()); }
        }
    
        public interface IServiceSource
        {
            T GetService<T>() 
                where T : IService, new();
        }
    
        public class ServiceFactory : IServiceSource
        {
            public T GetService<T>() 
                where T : IService, new()
            {
                // I'm using Activator here just as an example
                return Activator.CreateInstance<T>();
            }
        }
    
        public class GenericTypeServiceCache : IServiceSource
        {
            IServiceSource _source;
    
            public GenericTypeServiceCache(IServiceSource source)
            {
                _source = source;
            }
    
            public T GetService<T>() 
                where T : IService, new()
            {
                var serviceInstance = GenericCache<T>.Instance;
                if (serviceInstance == null)
                {
                    serviceInstance = _source.GetService<T>();
                    GenericCache<T>.Instance = serviceInstance;
                }
    
                return serviceInstance;
            }
    
            // NOTE: This technique will cause all service instances cached here 
            // to be shared amongst all instances of GenericTypeServiceCache which
            // may not be desireable in all applications while in others it may
            // be a performance enhancement.
            private class GenericCache<T>
            {
                public static T Instance;
            }
        }
    
        public class CollectionBasedServiceCache : IServiceSource
        {
            private Dictionary<Type, IService> _serviceDictionary;
            IServiceSource _source;
    
            public CollectionBasedServiceCache(IServiceSource source)
            {
                _serviceDictionary = new Dictionary<Type, IService>();
                _source = source;
            }
    
            public T GetService<T>()
                where T : IService, new()
            {
    
                IService serviceInstance;
                if (!_serviceDictionary.TryGetValue(typeof(T), out serviceInstance))
                {
                    serviceInstance = _source.GetService<T>();
                    _serviceDictionary.Add(typeof(T), serviceInstance);
                }
    
                return (T)serviceInstance;
            }
    
            private class GenericCache<T>
            {
                public static T Instance;
            }
        }
    }
