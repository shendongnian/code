    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
             var runMode = args.Contains(@"/Console")
                 ? WindowsService.RunMode.Console
                 : WindowsService.RunMode.WindowsService;
             new WinodwsService().Run(runMode);
        }
    }
    public class WindowsService : ServiceBase
    {
        public enum RunMode
        {
            Console,
            WindowsService
        }
        public void Run(RunMode runMode)
        {
            if (runMode.Equals(RunMode.Console))
            {
                this.StartService();
                Console.WriteLine("Press <ENTER> to stop service...");
                Console.ReadLine();
                this.StopService();
                Console.WriteLine("Press <ENTER> to exit.");
                Console.ReadLine();
            }
            else if (runMode.Equals(RunMode.WindowsService))
            {
                ServiceBase.Run(new[] { this });
            }
        }
        protected override void OnStart(string[] args)
        {
            StartService(args);
        }
        protected override void OnStop()
        {
            StopService();
        }
        /// <summary>
        /// Logic to Start Service
        /// Public accessibility for running as a console application in Visual Studio debugging experience
        /// </summary>
        public virtual void StartService(params string[] args){ ... }
        /// <summary>
        /// Logic to Stop Service
        /// Public accessibility for running as a console application in Visual Studio debugging experience
        /// </summary>
        public virtual void StopService() {....}
    }
