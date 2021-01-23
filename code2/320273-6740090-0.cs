    namespace Sandbox
    {
        using System;
        using System.Collections.Generic;
        using System.Reflection;
        using System.Reflection.Emit;
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                var assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("Test"), AssemblyBuilderAccess.Run);
                var module = assembly.DefineDynamicModule("Test");
    
                var typeOne = module.DefineType("TypeOne", TypeAttributes.Public);
                var typeTwo = module.DefineType("TypeTwo", TypeAttributes.Public);
    
                typeOne.DefineField("Two", typeof(TestGeneric<>).MakeGenericType(typeTwo), FieldAttributes.Public);
                typeTwo.DefineField("One", typeof(TestGeneric<>).MakeGenericType(typeOne), FieldAttributes.Public);
    
                TypeConflictResolver resolver = new TypeConflictResolver();
                resolver.AddTypeBuilder(typeTwo);
                resolver.Bind(AppDomain.CurrentDomain);
    
                typeOne.CreateType();
                typeTwo.CreateType();
    
                resolver.Release();
    
                Console.WriteLine("Done");
                Console.ReadLine();
            }
        }
    
        public struct TestGeneric<T>
        {
        }
    
        internal class TypeConflictResolver
        {
            private AppDomain _domain;
            private Dictionary<string, TypeBuilder> _builders = new Dictionary<string, TypeBuilder>();
    
            public void Bind(AppDomain domain)
            {
                domain.TypeResolve += Domain_TypeResolve;
            }
    
            public void Release()
            {
                if (_domain != null)
                {
                    _domain.TypeResolve -= Domain_TypeResolve;
                    _domain = null;
                }
            }
    
            public void AddTypeBuilder(TypeBuilder builder)
            {
                _builders.Add(builder.Name, builder);
            }
    
            Assembly Domain_TypeResolve(object sender, ResolveEventArgs args)
            {
                if (_builders.ContainsKey(args.Name))
                {
                    return _builders[args.Name].CreateType().Assembly;
                }
                else
                {
                    return null;
                }
            }
        }
    }
