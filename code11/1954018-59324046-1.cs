    static string FilePath = "temp.bak";
    static IList<User> Users;
    
    public static bool FileLoad()
    {
        Users =
            File.ReadAllLines(FilePath)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => new User(line))
                .ToList(); ;
        return true;
        //false: try/catch, corrupted users data, invalid file, etc..
    }
