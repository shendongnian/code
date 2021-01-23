    public partial class App
        {
            private const string Guid = "250C5597-BA73-40DF-B2CF-DD644F044834";
            static readonly Mutex Mutex = new Mutex(true, "{" + Guid + "}");
            
            public App()
            {
                
                if (!Mutex.WaitOne(TimeSpan.Zero, true))
                {
                    //already an instance running
                    Application.Current.Shutdown();
                }
                else
                {
                    //no instance running
                }
            }
        }
