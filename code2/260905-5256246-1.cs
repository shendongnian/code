    public static void Main(string[] args)
    {
    TheType.MyClass aClass = new TheType.MyClass();
    Type t = aClass.GetType();
    MethodInfo[] mi = t.GetMethods();
    foreach(MethodInfo m in mi)
      Console.WriteLine("Method: {0}", m.Name);
    }
