    MyClass aClass = new MyClass();
    Type t = aClass.GetType();
    PropertyInfo[] pi = t.GetProperties();
    foreach (PropertyInfo prop in pi)
        Console.WriteLine("Prop: {0}", prop.Name);
