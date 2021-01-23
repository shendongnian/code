    public static Encoding DefaultEncoding
    {
        get
        {
    #if SILVERLIGHT
            return Encoding.UTF8;
    #else
            return Encoding.Default;
    #endif
        }
    }
