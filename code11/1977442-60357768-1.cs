    public abstract class NamedEntity
    {
        protected string name;
      
        public virtual string Name
        {
            get { return name; }
            set
            {
                //validation, if any
            }
        }
     
        public NamedEntity()
        {
            name = "";
        }
        
    }
     
    public class ProcessFile: NamedEntity
    {
        
        public override string Name
        {
            get { return base.Name; }
     
            set { base.Name = // new validation; }
        }
     
        public ProcessFile()
            : base()
        {
            base.Name = "";        
        }
    }
