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
    }
    if (timeOut)
    {
        // TODO: Handle your time out here.
    }
