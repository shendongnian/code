    public static Image FromFile(string path)
    {
        var bytes = File.ReadAllBytes(path);
        var ms = new MemoryStream(bytes);
        var img = Image.FromStream(ms);
        return img;
    }
