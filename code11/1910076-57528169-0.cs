    static class MLCsvHelper
    {
        public static void Patch(string file, out string patched)
        {
            patched = Path.ChangeExtension(file, "patched.csv");
            var mlContext = new MLContext();
            var data = mlContext.Data.LoadFromTextFile(file);
            using (var stream = File.Create(patched))
                mlContext.Data.SaveAsText(data, stream);
        }
    }
    MLCsvHelper.Patch("csv.txt", out var patched);
