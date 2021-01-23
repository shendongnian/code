            // unschedule jobs
            string[] groups = Scheduler.TriggerGroupNames;
            for (int i = 0; i < groups.Length; i++)
            {
                string[] names = Scheduler.GetTriggerNames(groups[i]);
                for (int j = 0; j < names.Length; j++)
                {
                    Scheduler.UnscheduleJob(names[j], groups[i]);
                }
            }
            // delete jobs
            groups = Scheduler.JobGroupNames;
            for (int i = 0; i < groups.Length; i++)
            {
                string[] names = Scheduler.GetJobNames(groups[i]);
                for (int j = 0; j < names.Length; j++)
                {
                    Scheduler.DeleteJob(names[j], groups[i]);
                }
            }
