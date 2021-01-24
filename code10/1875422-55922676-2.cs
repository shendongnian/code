    ZipArchive archive = new ZipArchive(zippedFolderStream);
    foreach (ZipArchiveEntry entry in archive.Entries)
    {
        string jsonDocumentContents = new StreamReader(entry.Open()).ReadToEnd();
        StringContent content = new StringContent(jsonDocumentContents, Encoding.ASCII, mediaType: "application/json");
    	HttpResponseMessage response = await httpClient.PostAsync($"http://127.0.0.1:9200/website/_bulk", content);
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
