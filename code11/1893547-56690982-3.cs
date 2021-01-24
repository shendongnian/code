    public void Test(ITest test)
    {
        if (test is TestA testA)
        {
            var foo = testA.A;
        }
        if (test is TestB testB)
        {
            var foo = testB.B;
        }
    }
