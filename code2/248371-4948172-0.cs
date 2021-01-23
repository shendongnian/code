    var a = new byte[]
                {
                    1, 2, 3, 4, 4,
                    2, 3, 4, 2, 5,
                    3, 4, 4, 2, 6,
                    3, 4, 5, 3, 3
                };
    var b = new List<byte[]>();
    int groupSize = 5;
    for (int i = 0; i < a.Length; i += groupSize)
    {
        int interSize = Math.Min(a.Length - i, groupSize);
        var interByte = new byte[interSize];
        Buffer.BlockCopy(a, i, interByte, 0, interSize);
        b.Add(interByte);
    }
