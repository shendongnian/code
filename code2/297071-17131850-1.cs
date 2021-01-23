    private int checkdxversion_registry()
    {
        try
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\DirectX");
            string[] vals = rk.GetValueNames();
            string verstring = rk.GetValue(vals.Where(v => v == "Version").ToList()[0]).ToString();
            rk.Close();
            return Convert.ToInt32(verstring.Split('.')[1]);
        }
        catch (Exception ex)
        {
            return -1;
        }
    }
