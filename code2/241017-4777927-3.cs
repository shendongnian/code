    class Program
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Launching IIS Express...");
            IISExpress iis1 = IISExpress.Start(
                @"C:\Users\Administrator\Documents\IISExpress\config\applicationhost.config",
                @"WebSite1(1)",
                @"Clr4IntegratedAppPool");
            IISExpress iis2 = IISExpress.Start(
                @"C:\Users\Administrator\Documents\IISExpress\config\applicationhost2.config",
                @"WebSite1(1)",
                @"Clr4IntegratedAppPool");
            Console.Out.WriteLine("Press ENTER to kill");
            Console.In.ReadLine();
            iis1.Stop();
            iis2.Stop();
        }
    }
