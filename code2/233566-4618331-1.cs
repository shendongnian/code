    using System.ServiceProcess;
    //...
                System.ServiceProcess.ServiceController Service;
                Service = new ServiceController("myService");
                if (Service != null && Service.Status == ServiceControllerStatus.Stopped)
                        Service.Start();
    //...
