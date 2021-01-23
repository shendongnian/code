    public static class MyExtensions
    {
        public static void MyMethod(this object) { ... }
    } 
    object obj = new object();
    obj.MyMethod();
