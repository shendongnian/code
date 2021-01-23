    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    namespace VisitorPattern
    {
        class GenericVisitor<T>
        {
            // Dictionary whose key is the parameter type and value is the MethodInfo for method "Visit(ParameterType)"
            static Dictionary<Type, MethodInfo> s_visitorMethodDict;
            static GenericVisitor()
            {
                s_visitorMethodDict = new Dictionary<Type, MethodInfo>();
                Type visitorType = typeof(T);
                MethodInfo[] visitorMethods = visitorType.GetMethods();
                // Loop through all the methods in class T with the name "Visit".
                foreach (MethodInfo mi in visitorMethods)
                {
                    if (mi.Name != "Visit")
                        continue;
                    // Ignore methods with parameters > 1.
                    ParameterInfo[] parameters = mi.GetParameters();
                    if (parameters.Length != 1)
                        continue;
                    // Store the method in the dictionary with the parameter type as the key.
                    ParameterInfo pi = parameters[0];
                    if (!s_visitorMethodDict.ContainsKey(pi.ParameterType))
                        s_visitorMethodDict.Add(pi.ParameterType, mi);
                }
            }
            public static bool AcceptVisitor(object element, T visitor)
            {
                if (element == null || visitor == null)
                    return false;
                Type elementType = element.GetType();
                if (!s_visitorMethodDict.ContainsKey(elementType))
                    return false;
                
                // Get the "Visit" method on the visitor that takes parameter of the elementType
                MethodInfo mi = s_visitorMethodDict[elementType];
                // Dispatch!
                mi.Invoke(visitor, new object[] { element });
                return true;
            }
        }
        // Element classes (note: they don't necessarily have to be derived from a base class.)
        class A { }
        class B { }
        class Visitor
        {
            public void Visit(A a) { System.Console.WriteLine("Visitor: Visited A"); }
            public void Visit(B b) { System.Console.WriteLine("Visitor: Visited B"); }
        }
        interface IVisitor
        {
            void Visit(A a);
            void Visit(B b);
        }
        class DerivedVisitor : IVisitor
        {
            public void Visit(A a) { System.Console.WriteLine("DerivedVisitor: Visited A"); }
            public void Visit(B b) { System.Console.WriteLine("DerivedVisitor: Visited B"); }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Object a = new A();
                Object b = new B();
                // Example of Visitor that doesn't use inheritance.
                Visitor v1 = new Visitor();
                GenericVisitor<Visitor>.AcceptVisitor(a, v1);
                GenericVisitor<Visitor>.AcceptVisitor(b, v1);
                // Example of Visitor that uses inheritance.
                IVisitor v2 = new DerivedVisitor();
                GenericVisitor<IVisitor>.AcceptVisitor(a, v2);
                GenericVisitor<IVisitor>.AcceptVisitor(b, v2);
            }
        }
    }
