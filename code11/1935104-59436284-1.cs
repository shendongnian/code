    public  string Encryption(string strText)
    { 
      var publicKey = "XXXXXXXXXXXXX The Key Value XXXXXXXXXXXXX";
      var testData = Encoding.UTF8.GetBytes(strText);
      RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);
    
      // client encrypting data with a public key issued by server                    
        rsa.FromXmlString(publicKey.ToString());
    
       var encryptedData = rsa.Encrypt(testData, true);
    
       var base64Encrypted = Convert.ToBase64String(encryptedData);
    
        string retval = base64Encrypted.ToString();
    
        if (HaxVal1.Equals(HaxVal))
        {
            return retval;
        }
        else
        {
            return "InvalidSignature";
        }
    }
