        List<DateTime> randomBeeps = new List<DateTime>();
        Random rand = new Random();
        for( int j = 0; j < numberBeepsNeeded; j++ )
        {
             int randInt = rand.Next();
             double percent = ((double)randInt) / Int32.MaxValue;
             double randTicksOfTotal = ((double)setAmountOfTime.Ticks) * percent;
             DateTime randomBeep = new DateTime((long)randTicksOfTotal);
             randomBeeps.Add(randomBeep);
        }
