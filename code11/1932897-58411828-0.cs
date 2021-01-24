    //Get the registry key containing the printer settings
    var regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\Print\\Printers\\" + PrinterName);
    if (regKey != null)
    {    
        //Get the value of the default printer preferences
        var defaultDevMode = (byte[])regKey.GetValue("Default DevMode");
        //Create a handle and populate
        var pDevMode = Marshal.AllocHGlobal(defaultDevMode.Length);
        Marshal.Copy(defaultDevMode, 0, pDevMode, defaultDevMode.Length);
        //Set the printer preferences
        pd.PrinterSettings.SetHdevmode(pDevMode);
        //Clean up
        Marshal.FreeHGlobal(pDevMode);
    }
