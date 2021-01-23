    public static class FileStreamExtensions
    {
        public static IEnumerable<string> GetLines(this FileStream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    yield return line;
            }
        }
        public static void WriteLines(this FileStream stream, IEnumerable<string> lines)
        {
            using (var writer = new StreamWriter(stream))
            {
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
    private void UpdateVersion(string file, string version)
    {
        using (FileStream inputFile = File.OpenRead(file))
        {
            string tempFilePath = Path.GetTempFileName();
        
            var transformedLines = inputFile.GetLines().Select(
                x => x.Trim().StartsWith("[assembly: AssemblyVersion")
                    ? "[assembly: AssemblyVersion\"" + version + "\")]"
                    : x
                );
        
            using (FileStream outputFile = File.OpenWrite(tempFilePath))
            {
                outputFile.WriteLines(transformedLines);
            }
        
            string backupFilename = Path.Combine(Path.GetDirectoryName(file), Path.GetRandomFileName());
            File.Replace(tempFilePath, file, backupFilename);
        }
    }
