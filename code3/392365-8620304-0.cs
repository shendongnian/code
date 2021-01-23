    public enum CostType
    { 
        Dollars,
        Percent 
    } 
   
    public class Foo
    {         
        public int CostTypes { get; set; }
        public Foo()
        { 
            CostTypes = (int)CostType.Dollars;
            // <--- error syntax highlighting on 'Dollars'
        }
    } 
