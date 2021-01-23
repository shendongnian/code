        private class LambdaHelper
        {
            public int VarI { get; set; }
        }
        private static void SomeMethod()
        {
            LambdaHelper helper = new LambdaHelper();
            Thread[] threads = new Thread[threadData.Length];
            for (helper.VarI = 0; helper.VarI < data.Length; helper.VarI++)
            {
              threads[helper.VarI] = new Thread(() => ThreadWork(data[helper.VarI]));
              threads[helper.VarI].Start();
            }
        }
