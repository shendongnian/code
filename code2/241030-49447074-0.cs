    class IISExpress
    {               
        private const string IIS_EXPRESS = @"C:\Program Files\IIS Express\iisexpress.exe";        
        private Process process;
        IISExpress(Dictionary<string, string> args)
        {
            this.Arguments = new ReadOnlyDictionary<string, string>(args);
            string argumentsInString = args.Keys
                .Where(key => !string.IsNullOrEmpty(key))
                .Select(key => $"/{key}:{args[key]}")
                .Aggregate((agregate, element) => $"{agregate} {element}");
            this.process = Process.Start(new ProcessStartInfo()
            {
                FileName = IIS_EXPRESS,
                Arguments = argumentsInString,
                WindowStyle = ProcessWindowStyle.Hidden                
            });
        }
        
        public IReadOnlyDictionary<string, string> Arguments { get; protected set; }        
        public static IISExpress Start(Dictionary<string, string> args)
        {
            return new IISExpress(args);
        }
        public void Stop()
        {
            try
            {
                this.process.Kill();
                this.process.WaitForExit();
            }
            finally
            {
                this.process.Close();
            }            
        }        
    }
