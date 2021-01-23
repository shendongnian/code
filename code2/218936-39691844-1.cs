    public static void WriteAllLinesBetter(string path, params string[] lines)
    {
        if (path == null)
            throw new ArgumentNullException("path");
        if (lines == null)
            throw new ArgumentNullException("lines");
        using (var stream = File.OpenWrite(path))
        using (StreamWriter writer = new StreamWriter(stream))
        {
            if (lines.Length > 0)
            {
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    writer.WriteLine(lines[i]);
                }
                writer.Write(lines[lines.Length - 1]);
            }
        }
    }
