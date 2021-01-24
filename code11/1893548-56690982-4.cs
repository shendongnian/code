    public void Test(ITest test)
    {
        var testA = test as TestA;
        var testB = test as TestB;
        if (testA != null)
        {
            var foo = testA.A;
        }
        if (testB != null)
        {
            var foo = testB.B;
        }
    }
