    using System.ServiceProcess;
    class Program
    {
        private const int _delay = 1000;
        private const int _period = 1000;
        private const string _serviceName = "mobsync";
        public static void Main(string[] args)
        {
            System.Threading.Timer timer = new System.Threading.Timer((o) =>
                {
                    string service = (string)o;
                    try
                    {
                        var sc = ServiceController.GetServices().FirstOrDefault(__s => __s.DisplayName == service);
                        
                        if(sc != null && sc.Status == ServiceControllerStatus.Running) 
                            sc.Stop();
                    }
                    catch
                    {
                        Console.WriteLine("Error when stopping service");
                    }
                }, _serviceName, _delay, _period);
            Console.ReadLine();
        }
    }
