    static void Main()
    {
        Demo("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
        Demo("mscorlib, Version=wrong version, Culture=neutral, PublicKeyToken=b77a5c561934e089");
        Demo("msshrtmi, Version=2.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
        Demo("msshrtmi, Version=2.6.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
        Demo("msshrtmi, Version=2.7.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
        Demo("msshrtmi, Version=2.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
    }
    static void Demo(string assemblyFullName) =>
        Console.WriteLine($"{assemblyFullName} is in GAC: {AssemblyHelper.AssemblyIsInGAC(assemblyFullName)}");
