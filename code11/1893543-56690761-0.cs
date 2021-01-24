     public void Test(ITest test)
            {
                if(test is TestA)
                {
                     ((TestA)test).A = 45678;
                }
            }
