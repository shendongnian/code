    public string GetEnglishName(string name)
            {
                string buffer2 = name;
                UInt32 iRet2 = new UInt32();
                iRet3 = PdhLookupPerfIndexByName(null, buffer2, ref iRet2);
                //Console.WriteLine(iRet2.ToString());
    
                RegistryKey pRegKey = Registry.LocalMachine;
                pRegKey = pRegKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Perflib\009");
                string[] after;
                after = (string[])pRegKey.GetValue("Counter");
                string value = iRet2.ToString();
                int pos = Array.IndexOf(after, value);
                return after[pos + 1];
            }
