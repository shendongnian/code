    static void Main(string[] args)
    {
       MyList<object> foo = new MyList<object>();
        
       MyMethod(foo);
    }
    static void MyMethod(List<object> things)
    {
       // No InvalidCastException when called...
    }
