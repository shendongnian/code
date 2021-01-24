protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Booking>().HasKey(b => b.PNNumber);
    modelBuilder.Entity<Booking>().HasData(
        new Booking { PNNumber = "11111", AccountName = "Boston Celtics" },
        new Booking { PNNumber = "22222", AccountName = "Miami Heat" });
    modelBuilder.Entity<ProcessStatusLog>().HasData(
        new ProcessStatusLog { ID = 1, PNNumber = "11111", InsuranceCode = "FIRE", Status = "NEW", UpdatedOn = DateTime.Parse("22/02/2020") },
        new ProcessStatusLog { ID = 2, PNNumber = "11111", InsuranceCode = "FIRE", Status = "FOR REVIEW", UpdatedOn = DateTime.Parse("23/02/2020") },
        new ProcessStatusLog { ID = 3, PNNumber = "22222", InsuranceCode = "FIRE", Status = "NEW", UpdatedOn = DateTime.Parse("24/02/2020") },
        new ProcessStatusLog { ID = 4, PNNumber = "22222", InsuranceCode = "MORTGAGE", Status = "NEW", UpdatedOn = DateTime.Parse("25/02/2020") },
        new ProcessStatusLog { ID = 5, PNNumber = "22222", InsuranceCode = "MORTGAGE", Status = "FOR REVIEW", UpdatedOn = DateTime.Parse("26/02/2020") },
        new ProcessStatusLog { ID = 6, PNNumber = "22222", InsuranceCode = "FIRE", Status = "CANCELLED", UpdatedOn = DateTime.Parse("28/02/2020") });
    base.OnModelCreating(modelBuilder);
}
Query:
public IActionResult Index()
{
    this.dbContext.Database.EnsureCreated();
    string givenPNNumber = "22222";
    var filteredLogs = dbContext.ProcessStatusLog
        .Where(log => log.PNNumber == givenPNNumber);
    // Get date of the latest log for each incurance code for eaxh PNNumber.
    var groupedLogs = filteredLogs
        .GroupBy(psl => psl.InsuranceCode)
        .Select(group => new
        {
            Code = group.Key,
            LastUpdate = group.Max(g => g.UpdatedOn)
        });
    var result =
        from logs in filteredLogs
        join latestLogs in groupedLogs 
            on logs.InsuranceCode equals latestLogs.Code into joined
        from j in joined.DefaultIfEmpty()
        where logs.UpdatedOn == j.LastUpdate
        select logs.Status;
    string finalResult = string.Join(',', result.ToList());
    return View();
}
As I only used the in-memory Db I do not know how the EF will generate the query but the plan for the query is:
 - get the list of logs only for the given `PNNumber`,
 - from that filtered list get the list of `InsuranceCode`s for the given `PNNumber` along with the newest date of any log for that `PNNumber` and `InsuranceCode`
 - join the results (list of `InsuranceCode`, `UpdatedOn`, `Max(UpdatedOn)`
 - from that join select only the rows where `UpdatedOn == Max(UpdatedOn)` (latest entities for all `InsuranceCode`s for the given `PNNumber`)
 - select `Status`es
 - join them.
