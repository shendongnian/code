    public class ReportRepository : IReportRepository
    {
        private readonly ICollection<BaseContext> dbContexts;
    
        public ReportRepository(ICollection<BaseContext> dbContexts)
        {
            this.dbContexts = dbContexts;
        }
    }
