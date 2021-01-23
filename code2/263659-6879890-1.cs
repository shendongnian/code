    Assembly asm;
    Type[] types;
    asm = Assembly.LoadFile(@"C:\path\assembly.dll");
    types = asm.GetTypes() // throws FileNotFoundException.
    asm = Assembly.LoadFrom(@"C:\path\assembly.dll");
    types = asm.GetTypes() // Works!
