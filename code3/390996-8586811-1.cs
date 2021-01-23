    List<string> arr = new List<string>();    
    foreach (ServiceController scTemp in scServices)
    {
        if (scTemp.Status == ServiceControllerStatus.Running)
        {
            arr.add(scTemp.ServiceName);
        }
    }
    if (arr.Contains("YourWantedName")
    {
        // loop again
    }
    else
    {
        // send mail
    }
