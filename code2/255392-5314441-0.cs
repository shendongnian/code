    ~OutlookAccessor()
    {
        try
        {
            Outlook.Application app = new Outlook.Application();
            if (app.Explorers.Count == 0)
            {
                ((Outlook._Application)app).Quit();
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        }
        catch (System.Runtime.InteropServices.COMException)
        {
            ; // nevermind, we're only trying to free the Outlook COM object, and the most probable cause for this exception is that office is not installed.
        }
    }
