            RegistryKey key = Registry.LocalMachine;
            RegistryKey dataKey = key.OpenSubKey(@"Software\Avtec.Inc\LicenseKey");
            string licenceKey = dataKey.GetValue("required field name").ToString();
            using (BinaryWriter b = new BinaryWriter(File.Open("file.bin", FileMode.Create)))
            {
                b.Write(licenceKey);
                b.Close();
            }
