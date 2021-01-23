        List<byte[]> list = new List<byte[]>();
        list.Add(new byte[] { 1, 2, 3, 4 });
        list.Add(new byte[] { 1, 2, 3, 4 });
        list.Add(new byte[] { 1, 2, 3, 4 });
        IEnumerable<byte> result = Enumerable.Empty<byte>();
        foreach (byte[] bytes in list)
        {
            result = result.Concat(bytes);
        }
        byte[] newArray = result.ToArray();
