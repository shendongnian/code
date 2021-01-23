    [AssemblyInitialize()]
    public static void AssemblyInit(TestContext context)
    {
          GlobalBackend.EnsureStarted();
    }
