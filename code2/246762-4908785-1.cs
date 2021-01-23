    public struct OSVersion
    {
        public readonly string Name;
        public readonly Version Version;
    
        public OSVersion( string name, Version version )
        {
            Name = name;
            Version = version;
        }
    
        public const OSVersion WindowsXPSP3 = new OSVersion( "XP SP3", new Version(...) );
        public const OSVersion WindowsVistaSP1 = new OSVersion( "Vista SP1", new Version(...) );
        public const OSVersion Windows7 = new OSVersion( "Win7", new Version(...) );
    }
