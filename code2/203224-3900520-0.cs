    static void Main(string[] args)
    {
        string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MyCompany\MyApp");
        Directory.CreateDirectory(folder);
        using (StreamWriter writer = new StreamWriter(Path.Combine(folder, "app.log"), false))
        {
            writer.WriteLine("Logged.");
        }
    }
