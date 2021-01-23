    class Program
    {
        static void Main()
        {
            var type = Type.GetTypeFromProgID("COMTest.Foo");
            var instance = Activator.CreateInstance(type);
            type.InvokeMember("Bar", BindingFlags.InvokeMethod, null, instance, new object[0]);
        }
    }
