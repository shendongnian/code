csharp
internal class DatePeriodRepository: IDatePeriodRepository
{
    private readonly DateTimeOffset _dateCycleStart;
    public DatePeriodRepository(Options options)
    {
        _dateCycleStart = options.BillingPeriodCycleStart;
    }
    public Task<int> GetDatePeriod()
    {
        return GetDatePeriod(DateTimeOffset.Now);
    }
    public Task<int> GetDatePeriod(DateTimeOffset date)
    {
        var yearDiff = (date.Year - _billingCycleStart.Year) * 12;
        var monthDiff = yearDiff + date.Month - _dateCycleStart.Month;
        return Task.FromResult(monthDiff);
    }
}
