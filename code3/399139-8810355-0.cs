        ...
        var publisher = GetPublisher("My App Name");
        ...
        public static string GetPublisher(string application)
        {
            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall"))
            {
                var appKey = key.GetSubKeyNames().FirstOrDefault(x => GetValue(key, x, "DisplayName") == application);
                if (appKey == null) { return null; }
                return GetValue(key, appKey, "Publisher");
            }
        }
        private static string GetValue(RegistryKey key, string app, string value)
        {
            using (var subKey = key.OpenSubKey(app))
            {
                if (!subKey.GetValueNames().Contains(value)) { return null; }
                return subKey.GetValue(value).ToString();
            }
        }
