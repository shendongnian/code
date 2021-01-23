    class TrainResult
    {
        TrainResult(int x = 0; int y = 0)
        {
            this.X = x;
            this.Y = y;
        }
        public int X;
        public int Y;
    }
    // ...
    for(int y = 0; ...)
        for(int x = 0; ...)
            if(match ...)
                trainResults.Add(new TrainResult(x, y));
    // ...
    foreach(TrainResult result in trainResults)
    {
        // Do something with result.X, result.Y.
        // This is more obvious than result[0], result[1]
    }
