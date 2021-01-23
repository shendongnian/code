    public void LoadKeys(X509Certificate cert)
    {
    ....
    }
    #if !NET1.1
    public void LoadKeys(X509Certificate2 cert)
    {
    ....
    }
    #endif
