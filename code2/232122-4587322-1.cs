    namespace System.Net
    {
        class IPAddress
        {
            [Obsolete]
            public static bool operator ==(IPAddress a, IPAddress b) { return true; }
            [Obsolete]
            public static bool operator !=(IPAddress a, IPAddress b) { return true; }
        }
    }
