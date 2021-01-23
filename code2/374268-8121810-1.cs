    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                new BaseClass();
                new BaseClass();
                new DerivedClass();
    
                Console.WriteLine("Base classes: {0}, Derived classes: {1}",
                                  BaseClass.CountInstances<BaseClass>(),
                                  BaseClass.CountInstances<DerivedClass>());
            }
        }
    
        public class BaseClass
        {
            public static Dictionary<Type, int> InstanceCount =
                new Dictionary<Type, int>();
    
            public static int CountInstances<T>() where T : BaseClass
            {
                return BaseClass.InstanceCount.ContainsKey(typeof(T)) ? BaseClass.InstanceCount[typeof(T)] : 0;
            }
    
            public BaseClass()
            {
                if (!InstanceCount.ContainsKey(this.GetType()))
                {
                    InstanceCount[this.GetType()] = 0;
                }
    
                InstanceCount[this.GetType()]++;
            }
        }
    
        public class DerivedClass : BaseClass
        {
            public DerivedClass()
                : base()
            {
    
            }
        }
    }
