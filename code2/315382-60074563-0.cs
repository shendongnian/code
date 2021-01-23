    class AsyncPropertyTest
    {
    
        private static async System.Threading.Tasks.Task<int> GetInt(string text)
        {
            await System.Threading.Tasks.Task.Delay(1000);
            return int.Parse(text);
        }
    
    
        public static int MyProperty
        {
            get
            {
                int x = 0;
    
                // https://stackoverflow.com/questions/6602244/how-to-call-an-async-method-from-a-getter-or-setter
                // https://stackoverflow.com/questions/41748335/net-dispatcher-for-net-core
                // https://github.com/StephenCleary/AsyncEx
                Nito.AsyncEx.AsyncContext.Run(async delegate ()
                {
                    x = await GetInt("123");
                });
    
                return x;
            }
        }
    
    
        public static void Test()
        {
            System.Console.WriteLine(System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff"));
            System.Console.WriteLine(MyProperty);
            System.Console.WriteLine(System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff"));
        }
    
    
    }
