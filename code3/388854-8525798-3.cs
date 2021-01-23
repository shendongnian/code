    System.Security.Cryptography.RNGCryptoServiceProvider _crypto = new System.Security.Cryptography.RNGCryptoServiceProvider();
    
    byte[] bytes = new byte[8];
    _crypto.GetBytes( bytes );
    
    ulong randomNumber = (ulong)BitConverter.ToInt64( bytes, 0 );
    
    // convert to a string with the encoding of your choice; I prefer Base 62
