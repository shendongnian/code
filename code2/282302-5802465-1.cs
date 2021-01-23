    const int MAXVERK = 10;
    const int MAXTIP = 5;
    const int MAXKANAL = 3;
    
    private void LoadSystem() {
      BinaryReader reader;
    
      reader = new BinaryReader(File.OpenRead("E:\\test.dat"));
    
      if (reader.ReadByte() != 1) {
        throw new Exception("Wrong file type");
      }
    
      if (reader.ReadByte() != 1) {
        throw new Exception("Wrong file version");
      }
    
      ReadSystemRecord(reader);    
    }
    
    private void ReadSystemRecord(BinaryReader Reader) {
      for (int i = 0; i < MAXVERK; ++i) {
        ReadVerkRecord(Reader);
      }
      Int32 activeVerk = Reader.ReadInt32();
      ReadComRecord(Reader);
      byte hastighet = Reader.ReadByte();  // TODO: convert byte to the enum
      //...
    }
    
    private void ReadVerkRecord(BinaryReader Reader) {
      bool active = Reader.ReadByte() != 0;
      string name = ReadDelphiString(Reader, 40);
      string shortname = ReadDelphiString(Reader, 10);
      string formula = ReadDelphiString(Reader, 100);
      for (int i = 0; i < MAXTIP; ++i) {
        Int32 antalKanaler = Reader.ReadInt32();
      }
      for (int i = 0; i < MAXTIP; ++i) {
        for (int j = 0; j < MAXKANAL; ++j) {
          Int32 sondXref = Reader.ReadInt32();
        }
      }
      //...
    }
    
    private void ReadComRecord(BinaryReader Reader) {
      Int16 port = Reader.ReadInt16();
      Int16 baud = Reader.ReadInt16();
      Int16 stop = Reader.ReadInt16();
      Int16 data = Reader.ReadInt16();
      Int16 par = Reader.ReadInt16();
    }
    
    private string ReadDelphiString(BinaryReader Reader, int Length) {
      byte strlength = Reader.ReadByte();
      return System.Text.ASCIIEncoding.ASCII.GetString(Reader.ReadBytes(Length), 0, strlength);
    }
