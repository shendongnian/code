    public static class MyStaticClassInB
    {
    
        static MyStaticClassInB() { /*fill data here*/ }
    
        public static object GetData(Type type) { return MyStaticClass.GetData(type); }
    
        public static void SetData(Type type, object o) { MyStaticClass.SetData(type, o); }
    }
