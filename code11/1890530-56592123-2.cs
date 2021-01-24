    internal sealed class AtmRecord
    {
        public int ATMID { get; }
        public int StatusId { get; }
        public int ComponentId { get; }
        public DateTime FromDateTime { get; }
        public DateTime ToDateTime { get; }
    
        public AtmRecord(int aTMID, int statusId, int componentId, DateTime fromDateTime, DateTime toDateTime)
        {
            ATMID = aTMID;
            StatusId = statusId;
            ComponentId = componentId;
            FromDateTime = fromDateTime;
            ToDateTime = toDateTime;
        }
    }
    
    internal sealed class DateTimeRange
    {
        public DateTime From { get; set; }
    
        public DateTime To { get; set; }
    
        public DateTimeRange(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }
    }
