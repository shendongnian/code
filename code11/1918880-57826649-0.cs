    private void SaveButton_Click(object sender, EventArgs e)
    {
        string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        path = Path.Combine(path, "MyFile.txt");
        using(StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine("Hello!");
        }
    }
