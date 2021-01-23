    try
    {
        if (e.Error != null)
        {
            //UpdateUIStatus("Error loading user data", e.Error.Message);
            return;
        }
        var response = JObject.Parse(e.Result);
        if (response["response"].HasValues)
        {
            //Parse Code
        }
    }
    catch (Exception ex)
    {
        UpdateUIStatus("Could not load user data", ex.Message);
        // Logger.LogError(ex);
    }
