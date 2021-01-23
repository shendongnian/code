    void method1()
    {
        ExecuteMethodWithSetupAndCleanup(x =>
            {
                // here is the method1 specific code using x
            }
    }
    void method2()
    {
        ExecuteMethodWithSetupAndCleanup(x =>
            {
                // here is the method2 specific code using x
            }
    }
