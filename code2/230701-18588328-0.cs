    using System.ServiceProcess;
    bool serviceExists = false
    foreach (ServiceController sc in ServiceController.GetServices())
    {
        if (sc.ServiceName == "myServiceName")
        {
             //service is found
             serviceExists = true;
             break;
        }
    }
