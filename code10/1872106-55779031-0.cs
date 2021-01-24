    if (Directory.Exists(directoryPath))
    {
        var fileList = Directory.GetFiles(directoryPath).Select(Path.GetFileName);
        var clientDocList = documentRepository.Documents.Where(c => c.ClientID == clientID && !fileList.Contains(c.DocFileName.Trim())).ToList();
        documentRepository.Documents.RemoveRange(clientDocList);
    }
