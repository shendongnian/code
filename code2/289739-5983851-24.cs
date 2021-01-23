        class Program
        {
            static void Main(string[] args)
            {
                Exception exception = null;
                Thread thread = new Thread(() => SafeExecute(() => Test(0, 0), Handler));
                thread.Start();            
                
                Console.ReadLine();
            }
        
            private static void Handler(Exception exception)
            {        
                Console.WriteLine(exception);
            }
        
            private static void SafeExecute(Action test, Action<Exception> handler)
            {
                try
                {
                    test.Invoke();
                }
                catch (Exception ex)
                {
                    Handler(ex);
                }
            }
        
            static void Test(int a, int b)
            {
                throw new Exception();
            }
        }
