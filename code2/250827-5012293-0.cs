    public class Parent
    {
        protected IList<string> Names {get;set;}
        public virtual void Addnames()
        {
             Names = new List<string>(){"A", "B"};
        }
    }
    
    public class Child1
    {
        public override void Addnames()
        {
             base.Addnames();
             Names.Add("C");
        }
    }
    
    public class Child2
    {
        public override void Addnames()
        {
             Names = new List<string>(){"X", "Y", "Z"};
        }
    }
