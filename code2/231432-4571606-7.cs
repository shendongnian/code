    interface ITaskKeyGenerator
    {
        string GetTaskKey(Task task);
    }
    class BucketAlgorithm
    {
        public BucketAlgorithm(ITaskKeyGenerator taskKeyGenerator)
        {
            this.taskKeyGenerator = taskKeyGenerator;
        }
        private ITaskKeyGenerator taskKeyGenerator;
        public  Dictionary<string, TeamHours> BucketByProjectTask(Dictionary<string, TimeBooking> timebookings)
        {
            …
            dict[taskKeyGenerator.GetTaskKey(task)] = th;
            …
        }
    }
