    using System.Text;
    using System.Security.Cryptography;
    
      public static string ConvertStringtoMD5(string strword)
    {
        MD5 md5 = MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(strword);
        byte[] hash = md5.ComputeHash(inputBytes);
        StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
           { 
                sb.Append(hash[i].ToString("x2"));
           }
           return sb.ToString();
    }
