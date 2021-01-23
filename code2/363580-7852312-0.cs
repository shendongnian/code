    using (var context = new JobContext())
    {
        var originalJob = context.Jobs.Include(j => j.JobType)
            .Single(j => j.Id == job.Id);
        // Update scalar/complex properties
        context.Entry(originalJob).CurrentValues.SetValues(job);
        // Update reference
        originalJob.JobType = job.JobType;
        context.SaveChanges();
    }
