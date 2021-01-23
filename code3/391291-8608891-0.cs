    Stream fs = new FileStream(@file, FileMode.Open, FileAccess.Read);
    try
    {
      BinaryReader reader = new BinaryReader(fs);
      //PE Header starts @ 0x3C (60). Its a 4 byte header.
      fs.Position = 0x3C;
      uint peHeader = reader.ReadUInt32();
      //Moving to PE Header start location...
      fs.Position = peHeader;
      uint peHeaderSignature = reader.ReadUInt32();
      ushort machine = reader.ReadUInt16();
      ushort sections = reader.ReadUInt16();
      uint timestamp = reader.ReadUInt32();
      uint pSymbolTable = reader.ReadUInt32();
      uint noOfSymbol = reader.ReadUInt32();
      ushort optionalHeaderSize = reader.ReadUInt16();
      ushort characteristics = reader.ReadUInt16();
      long posEndOfHeader = fs.Position;
      ushort magic = reader.ReadUInt16();
      int off = 0x60; // Offset to data directories for 32Bit PE images
                      // See section 3.4 of the PE format specification.
      if (magic == 0x20b) //0x20b == PE32+ (64Bit), 0x10b == PE32 (32Bit)
      {
        off = 0x70;  // Offset to data directories for 64Bit PE images
      }
      fs.Position = posEndOfHeader;       
      uint[] dataDictionaryRVA = new uint[16];
      uint[] dataDictionarySize = new uint[16];
      ushort dataDictionaryStart = Convert.ToUInt16(Convert.ToUInt16(fs.Position) + off);
       
      fs.Position = dataDictionaryStart;
       
      for (int i = 0; i < 15; i++)
      {
        dataDictionaryRVA[i] = reader.ReadUInt32();
        dataDictionarySize[i] = reader.ReadUInt32();
      }
      if (dataDictionaryRVA[14] == 0)
      {
        fs.Close();
        return false;
      }
      else
      {
        fs.Close();
        return true;
      }
     }
     catch (Exception)
     {
       return false;
     }
     finally
     {
       fs.Close();
     }
