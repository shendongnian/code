      public void EncodeSingleFile(string inFile, string outFile)
      {
         using (FileStream inStream = new FileStream(inFile, FileMode.Open, FileAccess.Read))
         {
            using (FileStream outStream = new FileStream(outFile, FileMode.OpenOrCreate, FileAccess.Write))
            {
               EncodeSingleFile(inStream, outStream);
            }
         }
      }
      public void EncodeSingleFile(FileStream inStream, FileStream outStream)
      {
         bool eos = false;
         Int32 dictionary = 1 << 21;
         Int32 posStateBits = 2;
         Int32 litContextBits = 3; // for normal files
         // UInt32 litContextBits = 0; // for 32-bit data
         Int32 litPosBits = 0;
         // UInt32 litPosBits = 2; // for 32-bit data
         Int32 algorithm = 2;
         Int32 numFastBytes = 128;
         string mf = "bt4";
         propIDs = new CoderPropID[]
            {
               CoderPropID.DictionarySize,
               CoderPropID.PosStateBits,
               CoderPropID.LitContextBits,
               CoderPropID.LitPosBits,
               CoderPropID.Algorithm,
               CoderPropID.NumFastBytes,
               CoderPropID.MatchFinder,
               CoderPropID.EndMarker
            };
         properties = new object[]
            {
               dictionary,
               posStateBits,
               litContextBits,
               litPosBits,
               algorithm,
               numFastBytes,
               mf,
               eos
            };
			
         Encoder encoder = new Encoder();
         encoder.SetCoderProperties(propIDs, properties);
         encoder.WriteCoderProperties(outStream);
         Int64 fileSize = inStream.Length;
         for (int i = 0; i < 8; i++)
         {
            outStream.WriteByte((Byte) (fileSize >> (8*i)));
         }
         encoder.Code(inStream, outStream, -1, -1, null);
      }
