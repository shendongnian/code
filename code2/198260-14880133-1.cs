    private void SendKey(string key)
    {
        activateMediaCenterForm();
        try
        {
            SendKeys.SendWait(key);
        }
        catch (Exception e)
        {
            //Handle exception, if needed.
        }
    }
