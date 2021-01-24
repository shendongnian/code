public async Task<List<IOperation>> GetOperationsByEmployee(
    IDataService<IJobSchedule> JobScheduleRepository, 
    DateTime Date, 
    IEmployee Employee)
{
    var result = new List<IOperation>();
    var empSchedMatches = allEmployeeSchedules.Where(x => x.Date >= Date && x.Employee == Employee);
    var jobSchedules = new List<IJob>();
    foreach (var empSched in empSchedMatches)
    {
        var matches = allJobSched.Where(x => x.Date == empSched.Date && x.Crew == empSched.Crew);
        jobSchedules.AddRange(matches);
    }
    result = jobSchedules.Select(x => x.Operation).Distinct().ToList();
    return result;
}
**Question 2: How do I speed up this query?**
I got a bit of haranguing over ORM choice here, but I didn't have any concrete implementation steps to improve the code. Then, I had a conversation with a programmer who explained to me that he has a ton of experience using Entity Framework with SQLite. He gave me a couple of concrete pointers, and a code sample for how to improve the database loading speed. He explained that Entity Framework tracks objects that it loads, but if the operation is reading data that doesn't need to be tracked, the loading speed can be improved by turning off the tracking. He gave me the following code sample.
internal class ReadOnlyEFDatabase : EFDatabase
{
    public ReadOnlyEFDatabase(string dbPath, DbContextOptions options) : base(dbPath, options)
    {
        this.ChangeTracker.AutoDetectChangesEnabled = false;
        this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
    public override int SaveChanges()
    {
        throw new Exception("Attempting to save changes from a read-only connection to the database.");
    }
}
Thanks to Jeremy Sheeley from [zumero][1] for this help!!!!
  [1]: https://zumero.com
