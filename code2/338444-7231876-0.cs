        private static string GetDefaultBrowserPath()
        {
           string key = @"HTTP\shell\open\command";
           using(RegistryKey registrykey = Registry.ClassesRoot.OpenSubKey(key, false))
           {
              return ((string)registrykey.GetValue(null, null)).Split('"')[1];
           }
        }
        private static void Navigate(string url)
        {
           Process.Start(GetDefaultBrowserPath(), "file:///{0}".FormatWith(url));
        }
