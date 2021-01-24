    public class Job
    {
        public int Id { get; set; }
        public string SortName { get; set; }
    }
    
    public class Source
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
    
    public class JobType
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
    
    public class JobMethod
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public JobType JobType { get; set; }
    }
    
    public class Others
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public JobMethod JobMethod { get; set; }
        public object Notes { get; set; }
    }
    
    public class Tasks
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
    
    public class TargetData
    {
        public int PaymentId { get; set; }
        public string WantedNotes { get; set; }
        public string Name { get; set; }
    }
    
    public class Product
    {
        public Tasks Tasks { get; set; }
        public object Join { get; set; }
        public TargetData TargetData { get; set; }
        public object AdminDefinedFee { get; set; }
        public string Product { get; set; }
    }
    
    public class DataDummary
    {
        public string EnterKey { get; set; }
        public int Id { get; set; }
        public object Category { get; set; }
        public Job job { get; set; }
        public object Initiator { get; set; }
        public Source Source { get; set; }
        public double BalanceNow { get; set; }
        public bool ready { get; set; }
        public List<Others> Others { get; set; }
        public object Messages { get; set; }
        public List<Product> Products { get; set; }
    }
