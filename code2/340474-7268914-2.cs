    public static event EventHandler UnloadPageWorkaround;
    public void Application_Onexit(object sender, ExitEventArgs e)
    {
        UnloadPageWorkaround.Invoke(null, null);
    }
