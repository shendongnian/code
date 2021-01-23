    public override void Install(System.Collections.IDictionary stateSaver)
    {
        base.Install(stateSaver);
        rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        if (rkApp.GetValue("MyApp") == null)
        {
            rkApp.SetValue("MyApp", this.Context.Parameters["assemblypath"]);
        }
        else
        {
            if (rkApp.GetValue("MyApp").ToString() != this.Context.Parameters["assemblypath"])
            {
                rkApp.SetValue("MyApp", this.Context.Parameters["assemblypath"]);
            }
        }
    }
    public override void Uninstall(System.Collections.IDictionary savedState)
    {
        base.Uninstall(savedState);
        rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        if (rkApp.GetValue("MyApp") != null)
        {
            rkApp.DeleteValue("MyApp", false);
        }
    }
