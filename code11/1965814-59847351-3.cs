    List<int> ints = new List<int>();
    var workBuffer = new byte[4];
    for (int i = 0; i <= fullFile.Length; i += 3)
    {
        // Copy the three bytes into the beginning of the temp buffer
        Buffer.BlockCopy(fullFile, i, workBuffer, 0, 3);
        // Now we can use ToInt32 as the last byte always is zero
        var value = BitConverter.ToInt32(workBuffer, 0);
        ints.Add(value);
    }
