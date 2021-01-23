    using System;
    using System.Text;
    using Quartz;
    using Quartz.Impl;
    using Quartz.Impl.Calendar;
    using Quartz.Listener;
    using Quartz.Impl.Matchers;
    using System.Threading;
    
    namespace QuartzNET.Samples
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Create RAMJobStore instance
                DirectSchedulerFactory.Instance.CreateVolatileScheduler(5);
                ISchedulerFactory factory = DirectSchedulerFactory.Instance;
    
                // Get scheduler and add object
                IScheduler scheduler = factory.GetScheduler();          
    
                StringBuilder history = new StringBuilder("Runtime History: ");
                scheduler.Context.Add("History", history);
    
                JobKey firstJobKey = JobKey.Create("FirstJob", "Pipeline");
                JobKey secondJobKey = JobKey.Create("SecondJob", "Pipeline");
                JobKey thirdJobKey = JobKey.Create("ThirdJob", "Pipeline"); 
                
                // Create job and trigger
                IJobDetail firstJob = JobBuilder.Create<FirstJob>()
                                           .WithIdentity(firstJobKey)
                                           //.StoreDurably(true)
                                           .Build();
    
                IJobDetail secondJob = JobBuilder.Create<SecondJob>()
                                           .WithIdentity(secondJobKey)                                       
                                           .StoreDurably(true)                                       
                                           .Build();
    
                IJobDetail thirdJob = JobBuilder.Create<ThirdJob>() 
                                           .WithIdentity(thirdJobKey)
                                           .StoreDurably(true)
                                           .Build();
    
                ITrigger firstJobTrigger = TriggerBuilder.Create()
                                                 .WithIdentity("Trigger", "Pipeline")
                                                 .WithSimpleSchedule(x => x
                                                     .WithMisfireHandlingInstructionFireNow()
                                                    .WithIntervalInSeconds(5)    
                                                    .RepeatForever())
                                                 .Build();
    
                JobChainingJobListener listener = new JobChainingJobListener("Pipeline Chain");
                listener.AddJobChainLink(firstJobKey, secondJobKey);
                listener.AddJobChainLink(secondJobKey, thirdJobKey);            
    
                scheduler.ListenerManager.AddJobListener(listener, GroupMatcher<JobKey>.GroupEquals("Pipeline"));
    
                // Run it all in chain
                scheduler.Start();
                scheduler.ScheduleJob(firstJob, firstJobTrigger);
                scheduler.AddJob(secondJob, false, true);
                scheduler.AddJob(thirdJob, false, true);
    
                Console.ReadLine();
                scheduler.Shutdown();
                Console.WriteLine("Scheduler shutdown.");
                Console.WriteLine(history);
                Console.ReadLine();
            }
        }
    
        class FirstJob : IJob
        {
            public void Execute(IJobExecutionContext context)
            {
                var history = context.Scheduler.Context["History"] as StringBuilder;
                history.AppendLine();
                history.AppendFormat("First {0}", DateTime.Now);            
                Console.WriteLine("First {0}", DateTime.Now);
            }
        }
    
        class SecondJob : IJob 
        {
            public void Execute(IJobExecutionContext context)
            {
                var history = context.Scheduler.Context["History"] as StringBuilder;
                history.AppendLine();
                history.AppendFormat("Second {0}", DateTime.Now);
                Console.WriteLine("Second {0}", DateTime.Now);            
            }
        }
    
        class ThirdJob : IJob
        {
            public void Execute(IJobExecutionContext context)
            {
                var history = context.Scheduler.Context["History"] as StringBuilder;
                history.AppendLine();
                history.AppendFormat("Third {0}", DateTime.Now);
                Console.WriteLine("Third {0}", DateTime.Now);
                Console.WriteLine();
            }
        }
    }
