    using System;
    using Microsoft.Win32;
    
    class Test
    {
        static void Main()
        {
            using (var key = Registry.CurrentUser.OpenSubKey
                   (@"Software\Microsoft\Windows\CurrentVersion\" + 
                    @"Explorer\ComDlg32\LastVisitedMRU", false))
            {
                string value = (string) key.GetValue("MRUList");
                Console.WriteLine(value);            
            }
        }
    }
