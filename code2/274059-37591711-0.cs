     public static string DecryptString(string encriptedText, string key)
       {
           try
           {
               
               //Convert the text into bytest
               byte[] ecriptedBytes = System.Convert.FromBase64String(encriptedText);
               // Create a memory stream to the passed buffer
               MemoryStream objMemStream = new MemoryStream(ecriptedBytes);
               //Set the legal keys and initialization verctors
               objCrptoService.Key = GetLegalsecretKey(key);
               objCrptoService.IV = GetLegalIV();
               // Create a CryptoStream using the memory stream and the cryptographic service provider  version
               // of the Data Encryption stanadard algorithm key
               CryptoStream objCryptStream = new CryptoStream(objMemStream, objCrptoService.CreateDecryptor(), CryptoStreamMode.Read);
               // Create a StreamReader for reading the stream.
               //StreamReader objstreamReader = new StreamReader(objCryptStream);
               MemoryStream stream = new MemoryStream();
               objCryptStream.CopyTo(stream);
               stream.Position = 0;
               StreamReader R = new StreamReader(stream);
               string outputText = R.ReadToEnd();
               // Close the streams.
               R.Close();
               objCryptStream.Close();
               objMemStream.Close();
               return outputText;
           }
           catch (Exception exc)
           {
               return "";
           }
       }
