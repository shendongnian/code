            foreach (CronTrigger trigger in triggers.OfType<CronTrigger>())
            {
                trigger.CronExpressionString = txtCron.Text;
                sched.UnscheduleJob(triggers[0].Name, triggers[0].Group);
                sched.RescheduleJob(trigger.Name, trigger.Group, trigger);
            }
