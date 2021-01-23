        Stream s = new MemoryStream();
        for (int i = 0; i < 100; i++)
        {
            s.WriteByte((byte)i);
        }
        s.Position = 0;
