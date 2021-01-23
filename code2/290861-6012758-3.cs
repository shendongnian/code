    public class ScheduledItem : ITableOperations<ScheduledPostEntity, Guid, DateTime>
    {
        public string PartitionKey(Guid userGuid)
        {
            return userGuid.ToString();
        }
        public string RowKey(DateTime dateScheduled)
        {
            return dateScheduled.ReverseTicks();
        }
    }
