    MemoryStream msTestString = new MemoryStream();
    Serializer.Serialize(msTestString, registrationBlocks);
    
    string stringBase64 = Convert.ToBase64String(msTestString.ToArray());
    
    byte[] byteAfter64 = Convert.FromBase64String(stringBase64);
    MemoryStream afterStream = new MemoryStream(byteAfter64);
    
    List<RVRegistrationBlock> CopiedBlocksString = new List<RVRegistrationBlock>();
    CopiedBlocksString = Serializer.Deserialize<List<RVRegistrationBlock>>(afterStream);
