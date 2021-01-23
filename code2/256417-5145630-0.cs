    class MyClass
    {
        public static String val = "test";
        public static void Main()
        {
            FieldInfo myf = typeof(MyClass).GetField("val");
            Console.WriteLine(myf.GetValue(null));
            val = "hi";
            Console.WriteLine(myf.GetValue(null));
        }
    }
