    private static void MethodCommon(Func f)
    {
        DoThisStepFirst();
        f();
    }
    
    private static void Method1()
    {
        MethodCommon(() => 
            doSomething();
        );
    }
