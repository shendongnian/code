    static string GetDeviceGuid()
        {
            const string AdapterKey = "SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E972-E325-11CE-BFC1-08002BE10318}";
            RegistryKey regAdapters = Registry.LocalMachine.OpenSubKey(AdapterKey);
            string[] keyNames = regAdapters.GetSubKeyNames();
            foreach (string x in keyNames) {
                Console.WriteLine(x);
            }
            string devGuid = "";
            Regex rx = new Regex(@"\d{4}",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (string x in keyNames)
            {
                if (!rx.IsMatch(x)) {
                    continue;
                } 
                RegistryKey regAdapter = regAdapters.OpenSubKey(x);
                object id = regAdapter.GetValue("ComponentId");
                if (id != null && id.ToString() == "tap0901") devGuid = regAdapter.GetValue("NetCfgInstanceId").ToString();
            }
            return devGuid;
        }
