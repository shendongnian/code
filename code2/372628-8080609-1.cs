    using System.ServiceProcess;
    class Program
    {
        private const int _delay = 1000;
        private const int _period = 1000;
        private const string _serviceName = "mobsync";
        public static void Main(string[] args)
        {
            var sc = ServiceController.GetServices().FirstOrDefault(__s => __s.DisplayName == _serviceName);
            // If service found, launch the timer
            if (sc != null)
            {
                System.Threading.Timer timer = new System.Threading.Timer((o) =>
                    {
                        var service = (ServiceController)o;
                        try
                        {
                            if (sc.Status == ServiceControllerStatus.Running)
                                sc.Stop();
                        }
                        catch
                        {
                            Console.WriteLine("Error when stopping service");
                        }
                    }, sc, _delay, _period);
            }
            else
            {
                Console.WriteLine("Unknown service : " + _serviceName);
            }
            Console.ReadLine();
        }
    }
