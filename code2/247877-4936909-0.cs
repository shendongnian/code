    StrongNameKeyPair kp;
    // Getting this from a resource would be a good idea.
    using(stream = GetStreamForKeyPair())
    {
        kp = new StrongNameKeyPair(fs);
    }
    AssemblyName an = new AssemblyName();
    an.KeyPair = kp;
    AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.RunAndSave);
