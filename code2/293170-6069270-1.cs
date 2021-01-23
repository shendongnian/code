    List<ServiceController> services = ServiceController.GetServices().ToList();
    ServiceController msQue = services.Find(o => o.ServiceName == "MSMQ");
    if (msQue != null) {
        if (msQue.Status == ServiceControllerStatus.Running) { 
            // It is running.
        }
    } else { // Not installed? }
