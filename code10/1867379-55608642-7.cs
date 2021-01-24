    using System;
    // removed by mma - using NetComClassLibrary3; // we can reference the .net dll as is
    namespace ConsoleApp10
    {
        // inserted by mma:
        [Guid("31dd1263-0002-4071-aa4a-d226a55116bd")]
        public interface IMyClass
        {
            event OnMyEventDelegate OnMyEvent;
            object MyMethod();
        }
        [Guid("31dd1263-0003-4071-aa4a-d226a55116bd")]
        public delegate void OnMyEventDelegate(string text);
        // end of insertion
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Bitness: " + IntPtr.Size);
                // note we don't use new MyClass() otherwise we may go inprocess
                // removed by mma var type = Type.GetTypeFromCLSID(typeof(MyClass).GUID);
                // inserted by mma:
                var type = Type.GetTypeFromProgID("NetComClassLibrary3.MyClass");
                // end of insertion
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
