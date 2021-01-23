    public class Meta { // Do not make this class a child class for flexibility and testing purposes.
        public string Name { get; set; }
    }
 
    public class IMeta { 
        string Name { get; set; }
    }
    
    public class TestItem : ITestItem {
        public TestItem() {
            this.Meta = new Meta();
            this.Items = new List<int>();
        public bool Enabled { get; set; }
        public IMeta Meta { get; internal set; }
        public List<int> Items { get; set; }
    }
    public interface ITestItem {
        bool Enabled { get; set; }        
        IMeta Meta { get;}
        IList<int> Items { get; set; }
    }
