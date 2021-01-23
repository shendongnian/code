    void throwException()
    {
        try
        {
            throw new NotImplementedException();
        }
        catch
        {
        }
    }
    void fileOpen()
    {
        string filename = string.Format("does_not_exist_{0}.txt", random.Next());
        try
        {
            File.Open(filename, FileMode.Open);
        }
        catch
        {
        }
    }
    void fileExists()
    {
        string filename = string.Format("does_not_exist_{0}.txt", random.Next());
        File.Exists(filename);
    }
    Random random = new Random();
