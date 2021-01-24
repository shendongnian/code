    class Program
    {
        static void Main(string[] args)
        {
            (new System.Security.Permissions.RegistryPermission(System.Security.Permissions.PermissionState.Unrestricted)).Assert();
    
            Microsoft.Win32.RegistryKey rkLanguages = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Control Panel\\International\\User Profile");
            foreach (string str in rkLanguages.GetSubKeyNames())
            {
                Console.WriteLine(str);
                Microsoft.Win32.RegistryKey rkLang = rkLanguages.OpenSubKey(str);
                foreach (string value in rkLang.GetValueNames())
                {
                    if (rkLang.GetValueKind(value) == Microsoft.Win32.RegistryValueKind.DWord)
                    {
                        string blah = String.Concat("SYSTEM\\CurrentControlSet\\Control\\Keyboard Layouts\\", value.Split(new char[] { ':' })[1]);
                        Microsoft.Win32.RegistryKey rkKeyboardLayout = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(blah);
                        Console.WriteLine(rkKeyboardLayout.GetValue("Layout Text"));
                    }
                }
                Console.WriteLine();
            }
    
            System.Security.CodeAccessPermission.RevertAssert();
        }
    }
