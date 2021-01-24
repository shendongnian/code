    using System;
    using NetComClassLibrary3; // we can reference the .net dll as is
    namespace ConsoleApp10
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Bitness: " + IntPtr.Size);
                // note we don't use new MyClass() otherwise we may go inprocess
                var type = Type.GetTypeFromCLSID(typeof(MyClass).GUID);
                var obj = (IMyClass)Activator.CreateInstance(type);
                // note I'm using the beloved dynamic keyword here. for some reason obj.OnMyEvent works but locally raises a cast error I've not investigated further...
                dynamic d = obj;
                d.OnMyEvent += (OnMyEventDelegate)((t) =>
                {
                    Console.WriteLine(t);
                });
                Console.WriteLine(obj.MyMethod());
            }
        }
    }
