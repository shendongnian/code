     public class FileEncryptRunner
     {
        Byte[] key = ASCIIEncoding.ASCII.GetBytes("thisisakeyzzzzzz");
        Byte[] IV = ASCIIEncoding.ASCII.GetBytes("thisisadeltazzzz");
    
        public void SaveEncryptedFile(string sourceFileName)
        {
           using (FileStream fStream = new FileStream(sourceFileName, FileMode.Open, FileAccess.Read, FileShare.Read),
                  outFStream = new FileStream(Environment.SpecialFolder.MyDocuments+"test.crp", FileMode.Create))
           {
              Rijndael RijndaelAlg = Rijndael.Create();
              using (CryptoStream cStream = new CryptoStream(outFStream, RijndaelAlg.CreateEncryptor(key, IV), CryptoStreamMode.Write))
              {
                  StreamWriter sWriter = new StreamWriter(cStream);
                  fStream.CopyTo(cStream);
              }
           }
        }
    
        public void ExecuteEncrypted()
        {
           using (FileStream fStream = new FileStream(Environment.SpecialFolder.MyDocuments + "test.crp", FileMode.Open, FileAccess.Read, FileShare.Read),
                  outFStream = new FileStream(Environment.SpecialFolder.MyDocuments + "crpTemp.exe", FileMode.Create))
           {
              Rijndael RijndaelAlg = Rijndael.Create();
              using (CryptoStream cStream = new CryptoStream(fStream, RijndaelAlg.CreateDecryptor(key, IV), CryptoStreamMode.Read))
              {   //Here you have a choice. If you want it to only ever exist decrypted in memory then you have to use the method in
                  // the linked answer.
                  //If you want to run it from a file than it's easy and you save the file and run it, this is simple.                                               
                  cStream.CopyTo(outFStream);
              }
           }
           Process.Start(Environment.SpecialFolder.MyDocuments + "crpTemp.exe");
        }
     }
    
    
    
