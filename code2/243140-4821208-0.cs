    public virtual string DisplayTime()
    {
        DateTime time = DateTime.Now; // Use current time
        string format = "MMM ddd d HH:mm yyyy"; // Use this format
        return time.ToString(format); // Write to console
    }
