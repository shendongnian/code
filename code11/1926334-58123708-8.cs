    public class ReportRepository : IReportRepository
    {
        private readonly NavaContext latamDbContext;
        private readonly StackContext euDbContext;
    
        public ReportRepository(NavaContext latamDbContext, StackContext euDbContext)
        {
            this.latamDbContext = latamDbContext;
            this.euDbContext = euDbContext;
        }
    }
