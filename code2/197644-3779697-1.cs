    if (scName == "informer")
    {
        try {
            using(ServiceController sc = new ServiceController(scTemp.ServiceName.ToString())) {
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    sc.Start();
                    MyLogEvent("Found service " + scTemp.ServiceName.ToString() + " which has status: " + sc.Status + "\nRestarting Service...");
                }
            }
        } catch {
            // Write debug log here
        }
    }
