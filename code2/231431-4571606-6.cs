    class abstract BucketAlgorithm
    {
        protected abstract string GetTaskKey(Task task);
        public  Dictionary<string, TeamHours> BucketByProjectTask(Dictionary<string, TimeBooking> timebookings)
        {
            …
            dict[GetTaskKey(task)] = th;
            …
        }
    }
    class SpecificBucketAlgorithm : BucketAlgorithm
    {
        protected override string GetTaskKey(Task task) { … }
    }
