    string path = "C:\\Users\\Clubs-2019";
    public List<Club> ReadClubsTxtFile()
    {
        return File.ReadAllLines(path)
                   .Select( line => new Club {SomeProperty = line} )
                   .ToList();
    }
