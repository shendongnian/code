            AppDomain otherAppDomain = AppDomain.CreateDomain("myDomain");
            otherAppDomain.UnhandledException += new UnhandledExceptionEventHandler(otherAppDomain_UnhandledException);
            Assembly assembly = otherAppDomain.Load("TheAssemblyThatThrows");
            // But you might need to have MyClass inherit from MarshalByRefObject
            MyClass instance = (MyClass)otherAppDomain.CreateInstanceAndUnwrap("TheAssemblyThatThrows", "MyClass");
            instance.DoSomething();
