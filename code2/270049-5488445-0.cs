    public class YourModelName
    {
           public IQueryable<Table1Data> FirstTableData { get; set;}
           public IQueryable<Table2Data> SecondTableData { get; set;}
           public YourModelName(IQueryable<Table1Data> d1, IQueryable<Table2Data> d2)
           {
                this.FirstTableData = d1;
                this.SecondTableData = d2;
           }
    }
