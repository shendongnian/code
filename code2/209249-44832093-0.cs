    using (var rootKeySystemCertificates = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\SystemCertificates", false))
    {
        foreach (var subKeyName in rootKeySystemCertificates.GetSubKeyNames())
        {
            var store = new X509Store(subKeyName, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            //your part with store.Certificates...
            store.Close();
        }
    }
