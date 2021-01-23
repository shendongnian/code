    private string CreateToken(string message, string secret)
    {
     secret = secret ?? "";
     var encoding = new System.Text.ASCIIEncoding();
     byte[] keyByte = encoding.GetBytes(secret);
     byte[] messageBytes = encoding.GetBytes(message);
     using (var hmacsha256 = new HMACSHA256(keyByte))
     {
     byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
     return Convert.ToBase64String(hashmessage);
     }
    }
