    private DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime Min = new DateTime(2006, 10, 1, 0, 0, 0);
    public DateTime Max = new DateTime(DateTime.Now.Ticks + TimeSpan.FromDays(365.25 * 4).Ticks);
    public int Duration { get; set; } = 5;
    public DateTime EndDate => new DateTime(StartDate.Ticks + TimeSpan.FromMinutes(Duration).Ticks);
