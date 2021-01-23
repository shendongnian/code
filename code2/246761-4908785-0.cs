    public struct OSVersion
    {
        public readonly string Name;
        public readonly Version Version;
    
        public OSVersion( string name, Version version )
        {
            Name = name;
            Version = version;
        }
    
        public static readonly OSVersion WindowsXPSP3 = new OSVersion( "XP SP3", new Version(...) );
        public static readonly OSVersion WindowsVistaSP1 = new OSVersion( "Vista SP1", new Version(...) );
        public static readonly OSVersion Windows7 = new OSVersion( "Win7", new Version(...) );
    }
