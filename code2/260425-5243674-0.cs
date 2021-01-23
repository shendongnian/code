    public long Duration {
        get {
            return (endDate - startDate).Ticks;
        }
    }
