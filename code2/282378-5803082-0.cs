     String fin = cell1.ToString();
    //Create variables to help with read and write.
    byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
    long rdlen = 0;              //This is the total number of bytes written.
    long totlen = fin.Length;    //This is the total length of the input file.
    int len;                     //This is the number of bytes to be written at a time.
    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();          
    CryptoStream encStream = new CryptoStream(cell1, tdes.CreateEncryptor(tdesKey, tdesIV), CryptoStreamMode.Write);
    Console.WriteLine("Encrypting...");
    //Read from the input file, then encrypt and write to the output file.
    while(rdlen < totlen)
    {
        len = fin.Read(bin, 0, 100);
        encStream.Write(bin, 0, len);
        rdlen = rdlen + len;
        Console.WriteLine("{0} bytes processed", rdlen);
    }
