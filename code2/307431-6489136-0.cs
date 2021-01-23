     string content = string.Empty;
        string ACLS=string.Empty;
        foreach (DocumentEntry entry in feed.Entries)
        {
  
        if (entry.IsDocument)
        {
        var stream = client.Query(new Uri(entry.Content.Src.ToString()));
        var reader = new StreamReader(stream);
        content = reader.ReadToEnd();
        }
        }
