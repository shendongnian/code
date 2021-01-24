    private static async Task WriteFile(string filePath, string text)
    {
        string temp_file = File.GetTempFileName();
        string base_path = AppDomain.CurrentDomain.BaseDirectory;
        using (StreamWriter outputFile = new StreamWriter(temp_file))
        {
            await outputFile.WriteAsync(text);
        }
        string file_path = Path.Combine(base_path, filePath);
        File.Copy(temp_file, file_path, true);
        File.Delete(temp_file);
    }
