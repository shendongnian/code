    var tasks = files.Select(async currentFile =>
        {
            if (currentFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await currentFile.CopyToAsync(ms);
                    return new DocumentData
                    {
                        BinaryData = ms.ToArray(),
                        FileName = currentFile.FileName
                    };
                }
            }
            return null;
        });
        
    var documents =  (await Task.WhenAll(tasks)).Where(d => d != null).ToArray();
