    public interface ITestItem
    {
     bool Enabled { get;set;}
     Meta Meta { get;set;}
     List<int> Items { get;set;}
     void ScheduleItem();
    }
