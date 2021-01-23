    public void PreCache(List<string> files)
    {
        foreach(string file in files)
             System.Drawing.Image.FromFile(file);
    }
