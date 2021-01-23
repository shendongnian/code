    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false,
     Inherited = false)]
    public class HelpAttribute : Attribute
    {
        public HelpAttribute(String Description_in)
        {
            this.description = Description_in;
            this.verion = "No Version is defined for this class";
        }
        protected String description;
        public String Description
        {
            get 
            {
                return this.description;
            }
        }
        protected String version;
        public String Version
        {
            get 
            {
                return this.version;
            }
            //if we ever want our attribute user to set this property, 
    
            //we must specify set method for it 
    
            set 
            {
                this.verion = value;
            }
        }
    }
    [Help("This is Class1")]
    public class Class1
    {
    }
    
    [Help("This is Class2", Version = "1.0")]
    public class Class2
    {
    }
    
    [Help("This is Class3", Version = "2.0", 
     Description = "This is do-nothing class")]
    public class Class3
    {
    }
