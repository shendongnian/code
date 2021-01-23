    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple=true, Inherited=true)]
    public class CategoryAttribute : Attribute
    {
        // Fields
        protected string categoryName;
    
        // Methods
        protected CategoryAttribute()
        {
            this.categoryName = base.GetType().Name;
            if (this.categoryName.EndsWith("Attribute"))
            {
                this.categoryName = this.categoryName.Substring(0, this.categoryName.Length - 9);
            }
        }
    
        public CategoryAttribute(string name)
        {
            this.categoryName = name.Trim();
        }
    
        // Properties
        public string Name
        {
            get
            {
                return this.categoryName;
            }
        }
    }
    
