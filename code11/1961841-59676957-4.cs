    public class JobSchedulerDependcenyService : IJobSchedulerService
    {
        JobScheduler jobScheduler;
        public JobSchedulerDependcenyService()
        {
            jobScheduler = (JobScheduler)MainActivity.Instance.GetSystemService(Android.Content.Context.JobSchedulerService);
        }
        public void StartJobSchedule()
        {
            ComponentName componentName = new ComponentName(MainActivity.Instance, Java.Lang.Class.FromType(typeof(DownloadJob)));
            JobInfo jobInfo = new JobInfo.Builder(1, componentName)
                .SetOverrideDeadline(0)
                .Build();
            //var jobScheduler = (JobScheduler)GetSystemService(JobSchedulerService);
            var scheduleResult = jobScheduler.Schedule(jobInfo);
            if (JobScheduler.ResultSuccess == scheduleResult)
            {
                var snackBar = Snackbar.Make(MainActivity.Instance.FindViewById(Android.Resource.Id.Content), "jobscheduled_success", Snackbar.LengthShort);
                snackBar.Show();
            }
            else
            {
                var snackBar = Snackbar.Make(MainActivity.Instance.FindViewById(Android.Resource.Id.Content), "jobscheduled_failure", Snackbar.LengthShort);
                snackBar.Show();
            }
            
        }
        public void CancelJobSchedule()
        {
            jobScheduler.CancelAll();
        }
    }
