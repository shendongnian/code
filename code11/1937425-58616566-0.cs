    public static List<Podcast> ReadPodcastsFromFile(string filepath)
    {
        if (!File.Exists(filepath)) return new List<Podcast>();
        string json = File.ReadAllText(filepath);
        return JsonConvert.DeserializeObject<List<Podcast>>(json);
    }
    public static void WritePodcastsToFile(List<Podcast> podcasts, string filepath)
    {
        string json = JsonConvert.SerializeObject(podcasts);
        // This will overwrite the file if it exists, or create a new one if it doesn't
        File.WriteAllText(filepath, json);
    }
