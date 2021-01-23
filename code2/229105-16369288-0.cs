    string ReadTextFromUrl(string url) {
        // WebClient is still convenient
        // Assume UTF8, but detect BOM - could also honor response charset I suppose
        using (var client = new WebClient())
        using (var stream = client.OpenRead(path))
        using (var textReader = new StreamReader(stream, Encoding.UTF8, true)) {
            return textReader.ReadToEnd();
        }
    }
