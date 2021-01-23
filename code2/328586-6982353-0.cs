    /// <devdoc> 
    /// <para>Gets the stream used for reading the body of the response from the 
    /// server.</para> 
    /// </devdoc> 
    public override Stream GetResponseStream() 
    { 
        if (Logging.On) 
            Logging.Enter(Logging.Web, this, "GetResponseStream", ""); 
        CheckDisposed(); 
        if (!CanGetResponseStream()) { 
            // give a blank stream in the HEAD case, which = 0 bytes of data 
            if (Logging.On) 
                Logging.Exit(Logging.Web, this, "GetResponseStream", 
                    Stream.Null); 
            return Stream.Null; 
        } 
        if (Logging.On) 
            Logging.PrintInfo(Logging.Web, 
                "ContentLength=" + m_ContentLength); 
        if (Logging.On) 
            Logging.Exit(Logging.Web, this, "GetResponseStream", 
                m_ConnectStream); 
        return m_ConnectStream; 
    } 
