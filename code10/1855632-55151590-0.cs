    public class TransactionDetail
    {
        public TransactionDetail(int id, 
            int batchId, 
            int metricCode, 
            DateTime reportingDate)
        {
            Id = id;
            BatchId = batchId;
            MetricCode = metricCode;
            ReportingDate = reportingDate;
        }
        public int Id { get; }
        public int BatchId { get; }
        public int MetricCode { get; }
        public DateTime ReportingDate { get; }
    }
    public class Measure
    {
        public Measure(int internalId, 
            int frequency)
        {
            InternalId = internalId;
            Frequency = frequency;
        }
        public int InternalId { get; }
        public int Frequency { get; }
    }
    public class Tmp
    {
        public Tmp(int id, 
            DateTime reportingDate)
        {
            Id = id;
            ReportingDate = reportingDate;
        }
        public int Id { get; }
        public DateTime ReportingDate { get; }
    }
