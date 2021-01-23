            const string REGISTRY_KEY = @"HKEY_CURRENT_USER\MyApplication";
            const string REGISTY_VALUE = "FirstRun";
            if (Convert.ToInt32(Microsoft.Win32.Registry.GetValue(REGISTRY_KEY, REGISTY_VALUE, 0)) == 0)
            {
                lblGreetings.Text = "Welcome New User";
                //Change the value since the program has run once now
                Microsoft.Win32.Registry.SetValue(REGISTRY_KEY, REGISTY_VALUE, 1, Microsoft.Win32.RegistryValueKind.DWord);
            }
            else
            {
                lblGreetings.Text = "Welcome Back User";
            }
