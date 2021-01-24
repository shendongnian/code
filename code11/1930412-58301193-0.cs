    String infoText = item.Name + item.Price + item.Expiration.ToString();
    Byte[] infoBytes = Encoding.UTF8.GetBytes( infoText );
    using( SHA256 sha = new SHA256Cng() )
    {
        Byte[] hash = sha.ComputeHash( infoBytes );
        String hashText = Convert.ToBase64String( hash );
    }
