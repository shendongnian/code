    var tasks = files.Select(async currentFile =>
    {
        if (currentFile.Length > 0)
        {
            using (var ms = new MemoryStream())
            {
                await currentFile.CopyToAsync(ms);
                documents.Add(new DocumentData
                {
                    BinaryData = ms.ToArray(),
                    FileName = currentFile.FileName
                });
            }
        }
    });
    
    await Task.WhenAll(tasks);
