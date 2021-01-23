    using (var context = new JobContext())
    {
        var jobType = job.JobType;
        job.JobType = null;
        context.JobTypes.Attach(jobType);
        context.Jobs.Attach(job);
        // change detection starts from here,
        // EF "thinks" now, original is JobType==null
        job.JobType = jobType;
        // change detection will recognize this as a change
        // and send an UPDATE to the DB
        
        context.Entry(job).State = EntityState.Modified; // for scalar/complex props
        context.SaveChanges();
    }
