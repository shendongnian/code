    public class ReportRepository : IReportRepository
    {
        private readonly NavaContext latamDbContext;
        private readonly EUContext euDbContext;
    
        public ReportRepository(NavaContext latamDbContext, EUContext euDbContext)
        {
            this.latamDbContext = latamDbContext;
            this.euDbContext = euDbContext;
        }
    }
