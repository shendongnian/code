    class YourClass
    {
        public static string acrobatPath;
        // This static constructor will be called before first access to your type.
        static YourClass()
        {
            acrobatPath = Registry.GetValue(@"HKEY_CLASSES_ROOT\Applications\AcroRD32.exe\shell\Read\command", "", 0).ToString();
            string[] split = new string[2];
            split = acrobatPath.Split('"');
            // mask path with ""
            acrobatPath = "\"" + split[1] + "\""; //get only path
        }
    }
