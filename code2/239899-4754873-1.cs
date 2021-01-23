    using System;
    using System.Security.Cryptography;
    using System.Text;
    
    private void example()
    {
        string data = "122ujhdheiwe";
    
        // Encrypt
        UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
        byte[] secret = ProtectedData.Protect(unicodeEncoding.GetBytes(data), null, DataProtectionScope.CurrentUser);
        Console.WriteLine(BitConverter.ToString(secret));
    
        // If you need it as a printable string, you can convert the binary to Base64
        string base64 = Convert.ToBase64String(secret);
        Console.WriteLine(base64);
    
        // Back to binary...
        byte[] backagain = Convert.FromBase64String(base64);
    
        // Decrypt
        byte[] clearbytes = ProtectedData.Unprotect(backagain, null, DataProtectionScope.CurrentUser);
        string roundtripped = unicodeEncoding.GetString(clearbytes);
        Console.WriteLine(roundtripped);
    }
