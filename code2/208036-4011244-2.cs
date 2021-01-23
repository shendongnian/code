    void Load(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File '" + path + "' does not exist.");
        }
        if (/* image is wrong size */)
        {
            throw new InvalidImageSizeException("File " + path + " is not in the correct size - expected 32x32 pixels");
        }
        // etc...
    }
