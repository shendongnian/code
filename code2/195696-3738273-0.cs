    public partial class MyEntityClass
    {
        private MyBaseClass _baseClass;
        private MyBaseClass BaseClass
        {
            get
            {
                if (_baseClass == null)
                {
                    _baseClass = new MyBaseClass();
                }
                return _baseClass;
            }
        }
    
        public string BaseClassString
        {
            get
            {
                return BaseClass.BaseClassString;
            }
            set
            {
                BaseClass.BaseClassString = value;
            }
        }
        // etc.
        public static implicit operator MyBaseClass(MyEntityClass e)
        {
            return new MyBaseClass() {
                Property1 = e.Property1,
                Property2 = e.Property2 // etc.
            };
        }
        public static implicit operator MyEntityClass(MyBaseClass b)
        {
            return new MyEntityClass() {
                Property1 = b.Property1,
                Property2 = b.Property2 // etc.
            };
        }
    }
