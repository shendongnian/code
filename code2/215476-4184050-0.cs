    public string GetSomeString(int someInt)
    {
        MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider();
        byte[] data = Encoding.ASCII.GetBytes(String.Format("{0}{1}", "methodName", someInt));
        data = cryptoServiceProvider.ComputeHash(data);
        return Convert.ToString(data);
    }
