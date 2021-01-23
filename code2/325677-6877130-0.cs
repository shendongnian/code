    static int RecurCount(string source)
    {
        int count = 0;
        try
        {
            var dirs = Directory.EnumerateDirectories(source);
            count = Directory.EnumerateFiles(source).Count();
            foreach (string dir in dirs)
            {
                count += RecurCount(dir);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return count;
    }
