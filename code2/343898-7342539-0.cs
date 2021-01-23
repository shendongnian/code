    private void button1_Click(object sender, EventArgs e)
            {
                RegistryKey rkey = Registry.LocalMachine;
                RegistryPermission f = new RegistryPermission(
                    RegistryPermissionAccess.Write | RegistryPermissionAccess.Read,
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Company\Product");
    
    
                /**********************/
                /* set registry keys  */
                /**********************/
                RegistryKey wtaKey = rkey.CreateSubKey(@"SOFTWARE\Company\Product\");
                try
                {
                    wtaKey.SetValue("key1", 123);
                    wtaKey.SetValue("key2", 567);
                    wtaKey.SetValue("key4", "some string");
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
