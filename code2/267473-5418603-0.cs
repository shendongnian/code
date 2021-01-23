    public interface ITestItem
    {
        bool Enabled { get; set; }        
        Meta Meta { get;}
        List<int> Items { get; set; }
    }
    
    public class Meta // Do not make this class a child class
    {   
        public string Name { get; set; }
    }
    class TestItem : ITestItem
    {
        public TestItem()
        {
            this.Meta = new Meta();
            this.Items = new List<int>();
        }
        public bool Enabled { get; set; }
        public Meta Meta { get; internal set; }
        public List<int> Items { get; set; }
    }
