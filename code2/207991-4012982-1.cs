            foreach (CronTrigger trigger in triggers.OfType<CronTrigger>())
            {
                trigger.CronExpressionString = txtCron.Text;
                sched.UnscheduleJob(trigger.Name, trigger.Group); //I would remove this 
                sched.RescheduleJob(trigger.Name, trigger.Group, trigger);
            }
