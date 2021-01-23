     public IEnumerable<Job> GetJobs(string jobNumber, string jobName, string projectDirectorName, string projectManagerName, string groupName) {
        IQueryable<Job> query = this._context.Jobs;
        if (!String.IsNullOrEmpty(jobNumber))
           query = query.Where(j => j.JobNumber.Contains(jobNumber));
        if (!String.IsNullOrEmpty(jobname))
           query = query.Where(j => j.JobName.Contains(jobName));
        // etc.
        return query;
    }
