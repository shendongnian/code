    using(System.Security.Cryptography.SHA1 hash = System.Security.Cryptography.SHA1.Create())
    { 
       System.Text.ASCIIEncoding encoder = new System.Text.ASCIIEncoding();   
       byte[] combined = encoder.GetBytes(str);   
       hash.ComputeHash(combined);   
    }
