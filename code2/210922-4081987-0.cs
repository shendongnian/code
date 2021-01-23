    using (FileStream file = File.OpenWrite("FileName.ext")) {
      using (BinaryWriter writer = new BinaryWriter(file)) {
        foreach (Data data in theList) {
          writer.Write(data.FirstShort);
          writer.Write(data.SecondShort);
          writer.Write(data.TheByte);
        }
      }
    }
