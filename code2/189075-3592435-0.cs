    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    
    namespace GetMethodsFromPublicTypes
    {
        class Program
        {
            static void Main(string[] args)
            {
                var assemblyName = @"FullPathAndFilenameOfAssembly";
    
                var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyName);
    
                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler(CurrentDomain_ReflectionOnlyAssemblyResolve);
    
                var methodsForType = from type in assembly.GetTypes()
                                     where type.IsPublic
                                     select new
                                         {
                                             Type = type,
                                             Methods = type.GetMethods().Where(m => m.IsPublic)
                                         };
    
                foreach (var type in methodsForType)
                {
                    Console.WriteLine(type.Type.FullName);
                    foreach (var method in type.Methods)
                    {
                        Console.WriteLine(" ==> {0}", method.Name);
                    }
                }
            }
    
            static Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
            {
                var a = Assembly.ReflectionOnlyLoad(args.Name);
                return a;
            }
        }
    }
