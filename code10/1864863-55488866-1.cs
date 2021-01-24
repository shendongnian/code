    public static string GetNonce()
    {
        // better to get unique random number if 
        // called mulitple times
        Random r = RandomProvider.GetThreadRandom(); 
        
        DateTime created = DateTime.Now;
        
        string nonce = Convert.ToBase64String(Encoding.ASCII.GetBytes(SHA1Encrypt(created + r.Next().ToString())));
        
        return nonce;
    }
