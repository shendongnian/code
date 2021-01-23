        private class LambdaHelper
        {
            public int VarI { get; set; }
        }
        private static int[] threadData;
        private static void SomeMethod()
        {
            LambdaHelper helper = new LambdaHelper();
            Thread[] threads = new Thread[threadData.Length];
            for (helper.VarI = 0; helper.VarI < threadData.Length; helper.VarI++)
            {
                threads[helper.VarI] = new Thread(() => ThreadWork(threadData[helper.VarI]));
                threads[helper.VarI].Start();
            }
        }
