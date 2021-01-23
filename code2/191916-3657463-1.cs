    Assembly asm = null;
    Type type = Type.GetType("TestNamespace.TestClass, ConsoleApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
    if (type != null)
    {
        asm = type.Assembly;
    }
        
