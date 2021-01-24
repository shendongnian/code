    public static class MyClass
    {
        public static int MyProp1 { get; set; } = 100;
        public static bool MyProp2 { get; set; } = false;
        private static Dictionary<string, object> dicPropValues;
        static MyClass()
        {
            dicPropValues = new Dictionary<string, object>();
            foreach(var prop in typeof(MyClass).GetProperties(BindingFlags.Static| BindingFlags.Public | BindingFlags.NonPublic))
            {
                dicPropValues[prop.Name] = prop.GetValue(null);
            }
        }
        public static (T,bool) GetDefault<T>(string propName)
        {
            if(dicPropValues.TryGetValue(propName, out object value))
            {
                return ((T)(value), true);
            }
            return (default, false);
        }
    }
    //test codes
    static void Main(string[] args)
    {
        MyClass.MyProp1 = 1000;
        MyClass.MyProp2 = true;
        var defaultValueOrProp1 = MyClass.GetDefault<int>("MyProp1");
        if(defaultValueOrProp1.Item2)
        {
            Console.WriteLine(defaultValueOrProp1.Item1);//100
        }
        var defaultValueOrProp2 = MyClass.GetDefault<bool>("MyProp2");
        if (defaultValueOrProp2.Item2)
        {
            Console.WriteLine(defaultValueOrProp2.Item1);//false
        }
    }
