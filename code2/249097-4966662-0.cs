    MemoryStream m = new MemoryStream();
    using (BinaryWriter writer = new BinaryWriter(m)) {
      writer.Write(2); // count
      writer.Write((short)3);
      writer.Write((short)3);
      writer.Write(2); // count
      writer.Write(4.4f);
      writer.Write(5.6f);
    }
    byte[] tab = m.ToArray();
