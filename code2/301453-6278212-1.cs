       EventRaiserJob : IJob
       {
           public void Execute(JobExecutionContext context)
           {
               Guid name = new Guid(context.JobDetail.Name);
               ScheduleTrigger.Triggers[name].RaiseEvent();
           }
       }
