        [TestMethod]
        public void MeasurePathPerfomance()
        {
            // repeat several times to avoid jit-issues
            for (int j = 0; j < 10; j++)
            {
                {
                    DateTime start = DateTime.Now;
                    string result;
                    for (int i = 0; i < 30000; i++)
                    {
                        result = System.IO.Path.Combine("a", "b", "c", "d"); // use 4 parameter version
                    }
                    TimeSpan spend = DateTime.Now - start;
                    System.Console.WriteLine("4 param : {0}", spend.TotalMilliseconds);
                }
                {
                    DateTime start = DateTime.Now;
                    string result;
                    for (int i = 0; i < 30000; i++)
                    {
                        result = System.IO.Path.Combine(new string[] { "a", "b", "c", "d" });
                    }
                    TimeSpan spend = DateTime.Now - start;
                    System.Console.WriteLine("array[4] param : {0}", spend.TotalMilliseconds);
                }
            }
        }
