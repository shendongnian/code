    class MyClass
    {
        List<Element> elements = new List<Element>();
        public MyClass()
        {
            elements[0] = new Element();
            //elements[0].MyMethod();
            Fun.InvokeMet(elements[0], "MyMethod");
        }
    }
    class Fun
    {
        public static void InvokeMet(object obj, string method)
        {
            string[] par = { };
            MethodInfo mi = obj.GetType().GetMethod(method);
            if (mi != null)
                mi.Invoke(obj, par);
        }
    }
