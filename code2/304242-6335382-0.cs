    var startTime = DateTime.Now;
    var endTime = DateTime.Now.AddSeconds(5);
    var timeOut = false;
    
    while (_dbConnection.State == ConnectionState.Connecting)
    {
        if (DateTime.Now.Compare(endTime) >= 0
        {
            timeOut = true;
            break;
        }
        Thread.Yield() //tells the kernel to give other threads some time
    }
    
    if (timeOut)
    {
        // TODO: Handle your time out here.
    }
