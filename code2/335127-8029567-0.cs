    static void Main(string[] args)
        {
            string NewPathEntry = @"%temp%\data";
            string NewPath = "";
            bool MustUpdate = true;
            string RegKeyName = @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment";
            string path = (string)Microsoft.Win32.Registry.LocalMachine.OpenSubKey(RegKeyName).GetValue
                ("Path", "", Microsoft.Win32.RegistryValueOptions.DoNotExpandEnvironmentNames);
            string[] paths = path.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string subPath in paths)
            {
                NewPath += subPath + ";";
                if (subPath.ToLower() == NewPathEntry.ToLower())
                {
                    MustUpdate = false;
                }
            }
            if (MustUpdate == true)
            {
                Environment.SetEnvironmentVariable("Path", NewPath + NewPathEntry, EnvironmentVariableTarget.Machine);
                {
                }
            }
        }
