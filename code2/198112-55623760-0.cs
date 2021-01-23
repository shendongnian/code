    static class Program
    {
        #region Private variable
        static readonly bool IsDebugMode = false;
        #endregion Private variable
        #region Constrcutors
        static Program()
        {
     #if DEBUG
            IsDebugMode = true;
     #endif
        }
        #endregion
        #region Main
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if (IsDebugMode)
            {
                MyService myService = new MyService(args);
                myService.OnDebug();             
            }
            else
            {
                ServiceBase[] services = new ServiceBase[] { new MyService (args) };
                services.Run(args);
            }
        }
        #endregion Main        
    }
