        public class RootObject
        {
            public string FolderPath { get; set; }
            public string FolderName { get; set; }
            public Template Template { get; set; }
        }
    and deserialize into that instead of `Template`:
        var jsonModel = JsonSerializer.Deserialize<RootObject>(jsonString);
