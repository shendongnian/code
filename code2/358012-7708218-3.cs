    public int PlayedCount()
    {
        int total = 0;
    
        foreach(Song s in this)
        {
            if (s.TimesPlayed > 0)
            {
                total++;
            }
        }
       
        return total;
    }
