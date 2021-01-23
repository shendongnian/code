    if (splashScreen != null)
    {
        if (splashScreen.IsHandleCreated)
        {
            try
            {
                splashScreen.Invoke(new MethodInvoker(() => splashScreen.Close()));
            }
            catch (InvalidOperationException)
            {
            }
        }
        splashScreen.Dispose();
        splashScreen = null;
    }
