    using System.Security.AccessControl;
    using Microsoft.Win32;
    public SomeForm()
    {
        InitializeComponent();
        WebBrowserAdvancedFeatures.ActivateWBAdvancedFeatures(Path.GetFileName(Application.ExecutablePath));
    }
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        WebBrowserAdvancedFeatures.DeactivateWBAdvancedFeatures(Path.GetFileName(Application.ExecutablePath));
        base.OnFormClosing(e);
    }
    // (...)
    class WebBrowserAdvancedFeatures
    {
        private static string baseKeyName = @"Software\Microsoft\Internet Explorer\Main\FeatureControl";
        private static string featuresKey = baseKeyName+ @"\FEATURE_BROWSER_EMULATION";
        private static string hardwareAccelKey = baseKeyName + @"\FEATURE_GPU_RENDERING";
        public static void ActivateWBAdvancedFeatures(string executableName)
        {
            using (var wbFeatureKey = Registry.CurrentUser.OpenSubKey(featuresKey,
                RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.WriteKey)) {
                wbFeatureKey.SetValue(executableName, 11001, RegistryValueKind.DWord);
            }
            using (var wbAccelKey = Registry.CurrentUser.OpenSubKey(hardwareAccelKey,
                RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.WriteKey)) {
                wbAccelKey.SetValue(executableName, 1, RegistryValueKind.DWord);
            }
        }
        public static void DeactivateWBAdvancedFeatures(string executableName)
        {
            using (var wbFeatureKey = Registry.CurrentUser.OpenSubKey(featuresKey,
                RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.WriteKey)) {
                wbFeatureKey.DeleteValue(executableName, false);
            }
            using (var wbAccelKey = Registry.CurrentUser.OpenSubKey(hardwareAccelKey,
                RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.WriteKey)) {
                wbAccelKey.DeleteValue(executableName, false);
            }
        }
    }
