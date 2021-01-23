    public Job(string description, double time, double rate)
    {
        Description = description;
        Time = time;
        Rate = rate;
    }
    public static Job operator +(Job first, Job second)
    {
        string newDescription = first.Description + " and " + second.Description;
        double newTime = first.Time + second.Time;
        double newRate = (first.Rate + second.Rate) / 2;
        double newTotalFee = newRate * newTime;
        return (new Job(newDescription, newTime, newRate));
    }
    public string Description { get; set; }
    public double Time { get; set; }
    public double Rate { get; set; }
}
