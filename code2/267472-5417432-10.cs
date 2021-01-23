    public interface ITestItem
    {
     bool Enabled { get;set;}
     Meta Properties { get;set;}
     List<int> Items { get;set;}
     void ScheduleItem();
    }
