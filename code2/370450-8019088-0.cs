    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Reflection;
    using System.Reflection.Emit;
    public class MainClass 
    {
        public static void Main()
        {
            PrintTypeParams(typeof(Tuple<int, double, string>));
        }
        private static void PrintTypeParams(Type t)
        {
            Console.WriteLine("Type FullName: " + t.FullName);
            Console.WriteLine("Number of arguments: " + t.GetGenericArguments().Length);
            Console.WriteLine("List of arguments:");
            foreach (Type ty in t.GetGenericArguments())
            {
                Console.WriteLine(ty.FullName);
                if (ty.IsGenericParameter)
                {
                    Console.WriteLine("Generic parameters:");
                    Type[] constraints = ty.GetGenericParameterConstraints();
                    foreach (Type c in constraints)
                    Console.WriteLine(c.FullName);
                }
            }
        }
    }
