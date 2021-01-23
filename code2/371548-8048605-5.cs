    using System;
     
    public string FDigest(string input)
    {
       MD5 md5 = System.Security.Cryptography.MD5.Create();
       byte[] ascii = System.Text.Encoding.ASCII.GetBytes (input);
       byte[] hash  = md5.ComputeHash (ascii);
     
       // Convert the byte array to hexadecimal string
       StringBuilder sb = new StringBuilder();
       for (int i = 0; i < hash.Length; i++)
           sb.Append (hash[i].ToString ("X2")); // "x2" for lowercase
       return sb.ToString();
    }
    
