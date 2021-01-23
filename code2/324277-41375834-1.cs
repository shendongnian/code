    [Test]
    public void SpecificCodeFromOP_WillNotFail_NotEvenOnEdgeCases()
    {
        int downtimeMinutes = 90;
        foreach (TimeSpan duration in new[] {
            TimeSpan.FromHours(2d), // From OP
            TimeSpan.MinValue,
            TimeSpan.Zero,
            TimeSpan.MaxValue })
        {
            decimal calculatedDowntimePercent = duration.TotalMinutes > 0 ?
                (downtimeMinutes / (decimal)duration.TotalMinutes) * 100.0m : 0.0m;
        }
    }
