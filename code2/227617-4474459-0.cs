    public static class PortableEnvironment
    {
        public static string NewLine
        {
            get
            {
    #if COMPACT_FRAMEWORK
                return "\r\n";
    #else
                return Environment.NewLine;
    #endif
            }
        }
    }
