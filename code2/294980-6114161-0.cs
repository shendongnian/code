    using System;
    using System.Linq;
    
    namespace ConsoleApplication
    {
        public class HasPublicParameterlessContructorClass
        {
        }
    
        public class DoesntHavePublicParameterlessContructorClass
        {
            private int someField;
    
            public DoesntHavePublicParameterlessContructorClass(int someParameter)
            {
                someField = someParameter;
            }
        }
    
        class Program
        {
            public static bool HasPublicParameterlessContructor(Type t)
            {
                return t.GetConstructors().Any(constructorInfo => constructorInfo.GetParameters().Length == 0);
            }
    
            static void Main()
            {
                Console.WriteLine(HasPublicParameterlessContructor(typeof(HasPublicParameterlessContructorClass)));
                Console.WriteLine(HasPublicParameterlessContructor(typeof(DoesntHavePublicParameterlessContructorClass)));
            }
        }
    }
