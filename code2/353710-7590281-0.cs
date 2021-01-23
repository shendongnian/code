     internal interface IEntity
        {
            int A { get; set; }
            int B { get; set; }
            Collection<int> GetCollection { get; }
        }
    
        internal class Entity : TrialBalanceHTMLToDataTable.TrialBalance.IEntity
        {
            public int A { get; set; }
            public int B { get; set; }
            public Collection<int> GetCollection
            {
                get{
                //dummy task 
                Collection<int> ints = new Collection<int>();
                //........ 
                return ints;
                }
            }
        }
    
    
        public class MyDropDownList : DropDownList
        {
            public MyDropDownList() { _Entity = new Entity(); }
    
            private IEntity _Entity { get; set; }
            protected override void OnLoad(EventArgs e)
            {
                this.DataSource = _Entity.GetCollection;
                this.DataBind();
            }
        }
