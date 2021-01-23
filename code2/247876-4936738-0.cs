    public static string GetRandomLine(ref string file) {
        List<string> lines = new List<string>();
        Random rnd = new Random();
        int i = 0;
     
        try {
            if (File.Exists(file)) {
                StreamReader reader = new StreamReader(file);
                while (!(reader.Peek() == -1))
                    lines.Add(reader.ReadLine());
                i = rnd.Next(lines.Count);
                reader.Close();
                reader.Dispose();
                return lines[i].Trim();
            }
            else {
                return string.Empty;
            }
        }
        catch (IOException ex) {
            MessageBox.Show("Error: " + ex.Message);
            return string.Empty;
        }
    }
