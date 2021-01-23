    class Test
        {
            public delegate void MyHandler(string x);
    
            public void RunTest()
            {
                var del = new MyHandler(Method);
                if (del is Delegate)
                {
                    Console.WriteLine(@"del is a delegate.");
                }
                else
                {
                    Console.WriteLine("del is not a delegate");
                }
    
            }
    
            private void Method(string myString)
            {
            }
        }
