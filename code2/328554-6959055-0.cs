    using (FileStream fs = new FileStream("", FileMode.Open, FileAccess.Read))
    {
        byte[] binaryFile = new byte[fs.Length];
        fs.Read(binaryFile, 0, buff.LongLength);
    
        //Copy the byte array to your email object.
    }
