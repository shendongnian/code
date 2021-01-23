    public int TotalLength()
    {
        get
        {
            int total = 0;
            foreach (Song s in this)
            {
                total += s.LengthInSeconds;
            }
            return total;    
        }
    }
