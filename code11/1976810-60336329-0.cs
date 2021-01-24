    var tasks  = files.Select(MyFuncAsync);
    Task.WhenAll(tasks);
    
    private async Task MyFuncAsync (currentFile)
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
    }
