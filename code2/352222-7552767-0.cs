    private IApplicationContext m_Context;
    public IApplicationContext ApplicationContext
    {
      set
      {
        m_Context = value;
      }
    }
    protected override object CreateJobInstance(TriggerFiredBundle bundle)
    {
      return m_Context.GetObject(bundle.JobDetail.JobType.Name, bundle.JobDetail.JobType);
    }
