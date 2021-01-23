        static void Main(string[] args)
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser;
                rk = rk.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\ComDlg32\LastVisitedMRU", false);
                PrintKeys(rk);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred: " + ex.Message);
            }
        }
        static void PrintKeys(RegistryKey rk)
        {
            if (rk == null)
            {
                Console.WriteLine("No specified registry key!");
                return;
            }
            foreach (String s in rk.GetValueNames())
            {
                if (s == "MRUList")
                {
                    continue;
                }
                Byte[] byteValue = (Byte[])rk.GetValue(s);
                UnicodeEncoding unicode = new UnicodeEncoding();
                string val = unicode.GetString(byteValue);
                Console.Out.WriteLine(val);
            }
            Console.ReadLine();
        }
