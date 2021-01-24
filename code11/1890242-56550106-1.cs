    void Main() {
        var av_searcher = new ManagementObjectSearcher(@"root\SecurityCenter2", "SELECT * FROM AntivirusProduct");
        foreach (ManagementObject info in av_searcher.Get()) {
            Console.WriteLine(info.Properties["displayName"].Value.ToString());
    
            var ps = ConvertToProviderStatus((uint)info.Properties["ProductState"].Value);
            Console.WriteLine(ps.SecurityProvider.ToString());
            Console.WriteLine(ps.AVStatus.HasFlag(AVStatusFlags.Enabled) ? "Enabled" : "Disabled");
            Console.Write("Signatures are ");
            Console.WriteLine(ps.SignatureStatus.HasFlag(SignatureStatusFlags.UpToDate) ? "up to date" : "out of date");
            Console.WriteLine()l
        }
    }
    
    [Flags]
    public enum ProviderFlags : byte {
        FIREWALL = 1,
        AUTOUPDATE_SETTINGS = 2,
        ANTIVIRUS = 4,
        ANTISPYWARE = 8,
        INTERNET_SETTINGS = 16,
        USER_ACCOUNT_CONTROL = 32,
        SERVICE = 64,
        NONE = 0,
    }
    
    [Flags]
    public enum AVStatusFlags : byte {
        Unknown = 1,
        Enabled = 16
    }
    
    [Flags]
    public enum SignatureStatusFlags : byte {
        UpToDate = 0,
        OutOfDate = 16
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct ProviderStatus {
        public SignatureStatusFlags SignatureStatus;
        public AVStatusFlags AVStatus;
        public ProviderFlags SecurityProvider;
        public byte unused;
    }
    
    public static unsafe ProviderStatus ConvertToProviderStatus(uint val) => *(ProviderStatus*)&val;
