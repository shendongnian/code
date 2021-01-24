public class CustomJob : SPJobDefinition
{
    public CustomJob() : base() { }
    public CustomJob(string jobName, SPService service) : base(jobName, service, null, SPJobLockType.None)
    {
        this.Title = jobName;
    }
    public CustomJob(string jobName, SPWebApplication webapp) : base(jobName, webapp, null, SPJobLockType.ContentDatabase)
    {
        this.Title = jobName;
    }
    public override void Execute(Guid targetInstanceId)
    {
        SPWebApplication webApp = this.Parent as SPWebApplication;
        try
        {
            // Your logic here
        }
        catch (Exception ex)
        {
            SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CustomJob - Execute", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, ex.Message, ex.StackTrace);
        }
    }
}
