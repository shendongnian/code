    public class ReportRepository : IReportRepository
    {
        private readonly IAppCache _cache;
        private readonly ILogger _logger;
        private SomeService _service;
        public string ServiceUrl { get; set; }
        public string RequestUri { get; set; }
     
        public ReportRepository(IAppCache appCache, ILogger<ShowDatabase> logger, SomeService service)
        {
            _service = service;
            _logger = logger;
            _cache = appCache;
        }
     
        public async Task<List<Show>> GetShows()
        {    
            var cacheKey = "kpi_{companyID}_{fromYear}_{fromMonth}_{toYear}_{toMonth}_{locationIDs}";
            Func<Task<List<DataSet>>> reportFactory = () => PopulateReportCache();
            //if you do it in DistributedCacheEntryOptions you do not need to set it here
            var absoluteExpiration = DateTimeOffset.Now.AddHours(1);
            var result = await _cache.GetOrAddAsync(cacheKey, reportFactory, absoluteExpiration);
            return result;
        }
      
        private async Task<List<DataSet>> PopulateReportCache()
        {
            List<DataSet> reports = await _service.GetData(ServiceUrl, RequestUri, out result);
            _logger.LogInformation($"Loaded {reports.Count} report(s)");
            return reports.ToList(); //I would have guessed it returns out parameter result ...
        }
    }
