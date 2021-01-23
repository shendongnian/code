    class Program
    {
      static void Main(string[] args)
      {
         WpRecType[] WpRec = new WpRecType[3];
         WpRec[0] = new WpRecType();
         WpRec[0].WpIndex = 0;
         WpRec[0].WpName = "New York";
         WpRec[0].WpLat = 40.783f;
         WpRec[0].WpLon = 73.967f;
         WpRec[0].WpLatDir = 1;
         WpRec[0].WpLonDir = 1;
         WpRec[1] = new WpRecType();
         WpRec[1].WpIndex = 1;
         WpRec[1].WpName = "Minneapolis";
         WpRec[1].WpLat = 44.983f;
         WpRec[1].WpLon = 93.233f;
         WpRec[1].WpLatDir = 1;
         WpRec[1].WpLonDir = 1;
         WpRec[2] = new WpRecType();
         WpRec[2].WpIndex = 2;
         WpRec[2].WpName = "Moscow";
         WpRec[2].WpLat = 55.75f;
         WpRec[2].WpLon = 37.6f;
         WpRec[2].WpLatDir = 1;
         WpRec[2].WpLonDir = 2;
         byte[] buffer = new byte[WpRecType.RecordSize];
         using (System.IO.FileStream stm = 
            new System.IO.FileStream(@"C:\Users\Public\Documents\FplDb.dat",
            System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite))
         {
            WpRec[0].SerializeInto(buffer);
            stm.Write(buffer, 0, buffer.Length);
            WpRec[1].SerializeInto(buffer);
            stm.Write(buffer, 0, buffer.Length);
            WpRec[2].SerializeInto(buffer);
            stm.Write(buffer, 0, buffer.Length);
            // Seek to record #1, load and display it
            stm.Seek(WpRecType.RecordSize * 1, System.IO.SeekOrigin.Begin);
            stm.Read(buffer, 0, WpRecType.RecordSize);
            WpRecType rec = new WpRecType(buffer);
            Console.WriteLine("[{0}] {1}: {2} {3}, {4} {5}", rec.WpIndex, rec.WpName,
               rec.WpLat, (rec.WpLatDir == 1) ? "N" : "S",
               rec.WpLon, (rec.WpLonDir == 1) ? "W" : "E");
         }
      }
    }
    class WpRecType
    {
      public short WpIndex;
      public string WpName;
      public Single WpLat;
      public Single WpLon;
      public byte WpLatDir;
      public byte WpLonDir;
      const int WpNameBytes = 40; // 20 unicode characters
      public const int RecordSize = WpNameBytes + 12;
      public void SerializeInto(byte[] target)
      {
         int position = 0;
         target.Initialize();
         BitConverter.GetBytes(WpIndex).CopyTo(target, position);
         position += 2;
         System.Text.Encoding.Unicode.GetBytes(WpName).CopyTo(target, position);
         position += WpNameBytes;
         BitConverter.GetBytes(WpLat).CopyTo(target, position);
         position += 4;
         BitConverter.GetBytes(WpLon).CopyTo(target, position);
         position += 4;
         target[position++] = WpLatDir;
         target[position++] = WpLonDir;
      }
      public void Deserialize(byte[] source)
      {
         int position = 0;
         WpIndex = BitConverter.ToInt16(source, position);
         position += 2;
         WpName = System.Text.Encoding.Unicode.GetString(source, position, WpNameBytes);
         position += WpNameBytes;
         WpLat = BitConverter.ToSingle(source, position);
         position += 4;
         WpLon = BitConverter.ToSingle(source, position);
         position += 4;
         WpLatDir = source[position++];
         WpLonDir = source[position++];
      }
      public WpRecType()
      {
      }
      public WpRecType(byte[] source)
      {
         Deserialize(source);
      }
    }
