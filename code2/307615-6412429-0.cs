    public Indicator GetIndicator(string name)
    {
        lock (indicators)
        {
            return indicators[name];
        }
    }
