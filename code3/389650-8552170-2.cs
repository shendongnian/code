    public X509Certificate2 Certificate     
    {
         get { return _certificate; }
         set { _certificate = value.PublicKey ?? null; }
    }
