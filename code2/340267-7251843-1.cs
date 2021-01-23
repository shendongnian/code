    public string AbsolutePath
    {
        get
        {
            if (this.IsNotAbsoluteUri)
            {
                throw new InvalidOperationException(SR.GetString("net_uri_NotAbsolute"));
            }
            string privateAbsolutePath = this.PrivateAbsolutePath;
            if (this.IsDosPath && (privateAbsolutePath[0] == '/'))
            {
                privateAbsolutePath = privateAbsolutePath.Substring(1); //HERE
            }
            return privateAbsolutePath;
        }
    }
 
