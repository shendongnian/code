    FileStream iFile = new FileStream(@"c:\test\binary.dat",
    FileMode.Open);
    
    long lengthInBytes = iFile.Length;
    
    BinaryReader bin = new BinaryReader(aFile);
    
    byte[] byteArray = bin.ReadBytes((int)lengthInBytes);
    
    System.Text.Encoding encEncoder = System.Text.ASCIIEncoding.ASCII;
    
    string str = encEncoder.GetString(byteArray);
