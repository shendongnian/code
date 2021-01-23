    float WaitTimeToShowCard = 0;
    public void Update(GameTime gametime)
    {
        if (HasToShowCard ()) 
        {
             WaitTimeToShowCard = 1;
        }
        if (WaitTimeToShowCard >0)
        {
             WaitTimeToShowCard -= (float) gametime.Elapsed.TotalSeconds;
             if (WaitTimeToShowCard <=0)
             {
                 WaitTimeToShowCard = 0;
                 ShowCard();
             } 
        }
    }
