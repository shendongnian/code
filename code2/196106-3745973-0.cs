    public string RandomLine( StreamReader reader )
    {
        string chosen = null;
        int numberSeen = 0;
        var rng = new Random();
        while ((string line = reader.ReadLine()) != null)
        {
            if (rng.NextInt(++numberSeen) == 0)
            {
                chosen = line;
            }
        }
        return chosen;
    }
