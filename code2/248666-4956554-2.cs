    public bool IsBetween(this DateTime thisTime, DateTime firstTime, DateTime secondTime) {
        if (secondTime < firstTime)
            secondTime = secondTime.AddDays(1);
        return firstTime < thisTime && thisTime < secondTime);
    }
    // to use...
    bool isDoTime = DateTime.Now.IsBetween(firstTime, secondTime);
