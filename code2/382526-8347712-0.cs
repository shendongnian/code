    class Base
    {
        public virtual string PropertyName { get; set; }
    }
    
    class Derived : Base
    {
        public override string PropertyName
        {
            get
            {
                return base.PropertyName + " Something";
            }
            set
            {
                base.PropertyName = value;
            }
        }
    }
