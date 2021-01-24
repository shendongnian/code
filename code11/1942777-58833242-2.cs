    public class JobsController : Controller
    {
        private readonly YourContext _context;
        public JobsController(YourContext context)
        {
            _context = context;
        }
        // GET: Jobs
        public async Task<ActionResult> Index()
        {
            var date = await _context.Job.Select(j => j.JobCompletion).Distinct().ToListAsync();
            var success =_context.Job
                .Where(j => j.JobStatus == "Success")
                .GroupBy(j => j.JobCompletion)
                .Select(group=>new {
                    JobCompletion = group.Key,
                    Count=group.Count()
                });
            var countSuccess = success.Select(a => a.Count).ToArray();
            var exception = _context.Job
                .Where(j => j.JobStatus == "Exception")
                .GroupBy(j => j.JobCompletion)
                .Select(group => new {
                    JobCompletion = group.Key,
                    Count = group.Count()
                });
            var countException = exception.Select(a => a.Count).ToArray();
            return new JsonResult(new { myDate=date,mySuccess= countSuccess, myException= countException });
        }
    }
