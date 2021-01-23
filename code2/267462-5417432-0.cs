    public class TestItem : ITestItem
    {
        public TestItem() { this.Meta = new Meta();}
        public bool Enabled { get; set; }
    
        //dont get confused here.
        public Meta Meta {get;get} //the second meta is the property name.
    
        public List<int> Items { get; set; }
      
        public ScheduleItem()
        {
            this.Items = new List<int>();
        }
        private class Meta
        {
            public string Name { get; set; }
        }
    }
.....
