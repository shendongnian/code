    var container = _client.GetContainerReference("test");
    container.CreateIfNotExists();
    var blob = container.GetBlockBlobReference(file.FileName);
    var blockDataList = new Dictionary<string, byte[]>();
    using (var stream = file.InputStream)
    {
        var blockSizeInKB = 1024;
        var offset = 0;
        var index = 0;
        while (offset < stream.Length)
        {
            var readLength = Math.Min(1024 * blockSizeInKB, (int)stream.Length - offset);
            var blockData = new byte[readLength];
            offset += stream.Read(blockData, 0, readLength);
            blockDataList.Add(Convert.ToBase64String(BitConverter.GetBytes(index)), blockData);
    
            index++;
        }
    }
    
    Parallel.ForEach(blockDataList, (bi) =>
    {
        blob.PutBlock(bi.Key, new MemoryStream(bi.Value), null);
    });
    blob.PutBlockList(blockDataList.Select(b => b.Key).ToArray());
