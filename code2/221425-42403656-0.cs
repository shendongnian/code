    string userName = "domain\user";
    string password = "whatever";
    string KEY_STR = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\ProfileList\\" + WindowsIdentity.GetCurrent().User.Value;
    WindowsImpersonationContext adminContext = Impersonation.getWic(userName, password);
    if (adminContext != null)
    {
        try
        {
           RegistryKey key = Registry.LocalMachine.OpenSubKey(KEY_STR, true);
           key.SetValue("State", 0x60001);
           Console.Out.WriteLine("User profile changed to Mandatory.");
        }
        catch (Exception ex)
        {
            Console.Out.WriteLine("\nUnable to set profile to Mandatory:\n\t" + ex.Message);
            Impersonation.endImpersonation();
            adminContext.Undo();
        }
        finally
        {
            Impersonation.endImpersonation();
            // The above line does what you had, here --            
            //if (tokenHandle != IntPtr.Zero) CloseHandle(tokenHandle);
            adminContext.Undo();
        }
    }
