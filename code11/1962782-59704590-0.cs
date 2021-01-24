    public static void CreateSceneFile(string Path, Scene Scene, bool Overwrite)
    {
        JsonSerializerSettings SerializerSettings = new JsonSerializerSettings();
        SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        SerializerSettings.TypeNameHandling = TypeNameHandling.Auto;
        string JSON = JsonConvert.SerializeObject(Scene, Formatting.Indented, SerializerSettings);
        File.WriteAllText(Path, JSON);
    }
