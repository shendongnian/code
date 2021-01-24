    public void EnablePrintBackground(bool value)
    {
        using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
            @"Software\Microsoft\Internet Explorer\PageSetup", true))
        {
            key.SetValue("Print_Background", value ? "yes" : "no",
                Microsoft.Win32.RegistryValueKind.String);
            key.Close();
        }
    }
