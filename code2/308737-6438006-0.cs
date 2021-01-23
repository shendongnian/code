    public virtual void Execute(JobExecutionContext context)
    {
        RunJob jobForm;
        var name = context.JobDetail.JobDataMap.GetString("Name");
        action(()=> { jobForm = new RunJob(); jobForm.Show(); jobForm.JobLabel = name;});
        
        for (int i = 0; i < 100; i++)
        {
            var txt = i.ToString();
            action(()=>{ jobForm.WriteLine(txt); });
        }
        action(()=> { jobForm.Hide(); });
    }
