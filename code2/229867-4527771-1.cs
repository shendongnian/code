    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Stackoverflow_4527626
    {
        delegate void CriteraDelegate(params object[] args);
    
        class CriteraManager
        {
            private Dictionary<Type, CriteraDelegate> criterian = new Dictionary<Type, CriteraDelegate>();
    
            public void RegisterCritera(Type type, CriteraDelegate del)
            {
                criterian[type] = del;
            }
    
            public void Execute(Object criteria, params object[] args)
            {
                Type type = criteria.GetType();
    
                /// Check to see if the specific type
                /// is in the list. 
                if (criterian.ContainsKey(type))
                {
                    criterian[type](args);
                }
                /// If it isn't perform a more exhaustive search for
                /// any sub types.
                else
                {
                    foreach (Type keyType in criterian.Keys)
                    {
                        if (keyType.IsAssignableFrom(type))
                        {
                            criterian[keyType](args);
                            return;
                        }
                    }
    
                    throw new ArgumentException("A delegate for Type " + type + " does not exist.");
                }
            }
        }
    
    
        interface InterfaceA { }
        interface InterfaceB1 : InterfaceA { }
        interface InterfaceB2 : InterfaceA { }
        interface InterfaceC { }
        class ClassB1 : InterfaceB1 { }
        class ClassB2 : InterfaceB2 { }
        class ClassC : InterfaceC { }
    
        class Program
        {
            static void ExecuteCritera1(params object[] args)
            {
                Console.WriteLine("ExecuteCritera1:");
                foreach (object arg in args)
                    Console.WriteLine(arg);
            }
    
            static void ExecuteCritera2(params object[] args)
            {
                Console.WriteLine("ExecuteCritera2:");
                foreach (object arg in args)
                    Console.WriteLine(arg);
            }
    
            static void Main(string[] args)
            {
                CriteraDelegate exampleDelegate1 = new CriteraDelegate(ExecuteCritera1);
                CriteraDelegate exampleDelegate2 = new CriteraDelegate(ExecuteCritera2);
    
                CriteraManager manager = new CriteraManager();
                manager.RegisterCritera(typeof(InterfaceB1), exampleDelegate2);
                manager.RegisterCritera(typeof(InterfaceB2), exampleDelegate2);
                manager.RegisterCritera(typeof(InterfaceC), exampleDelegate1);
    
                ClassB1 b1 = new ClassB1();
                ClassB2 b2 = new ClassB2();
                ClassC c = new ClassC();
    
                manager.Execute(b1, "Should execute delegate 2");
                manager.Execute(b2, "Should execute delegate 2");
                manager.Execute(c, "Should execute delegate 1");
            }
        }
    }
