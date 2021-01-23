    public class BaseClass
    {
        public virtual string StringInBaseClass {get;set;}
        public int IntInBaseClass {get;set;}
    }
    
    public class InheritingClass : BaseClass
    {
        [ScriptIgnore]
        public override string StringInBaseClass
        {
            get
            {
                return base.StringInBaseClass;
            }
            set
            {
                base.StringInBaseClass = value;
            }
        }
        public long LongInInheritingClass {get;set;}
        public long ShortInInheritingClass {get;set;}
        public long CharInInheritingClass {get;set;}
    }
