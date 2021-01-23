    public virtual void Execute(JobExecutionContext context)
    {
        string[] fileList = this.GetFileList(context);
        ...
    }
    
    private string[] GetFileList(JobExecutionContext) { ... }
