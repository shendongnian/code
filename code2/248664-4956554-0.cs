    public bool IsBetween(this DateTime thisTime, DateTime firstTime, DateTime secondTime) {
        return firstTime < thisTime && thisTime < secondTime);
    }
    // to use...
    bool isDoTime = DateTime.Now.Between(firstTime, secondTime);
