    [AttributeUsage(AttributeTargets.All)]
    public class MyAttribute : Attribute
    {
        private Nullable<int> _PropertyI;
        private Nullable<bool> _PropertyB;
        private String _Name;
        public int PropertyI
        {
            get
            {
                return _PropertyI.HasValue ? _PropertyI.Value : default(int);
            }
            set
            {
                this._PropertyI = value;
            }
        }
        public bool PropertyB
        {
            get
            {
                return _PropertyB.HasValue ? _PropertyB.Value : default(bool);
            }
            set
            {
                this._PropertyB = value;
            }
        }
        public String Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }
        public String[] GetAvailableParameters()
        {
            IList<String> names = new List<String>();
            Type type = this.GetType();
            FieldInfo[] fields
                = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (FieldInfo field in fields)
            {
                Type fieldType = field.FieldType;
                Object fieldValue = field.GetValue(this);
                if (fieldValue != null)
                {
                    names.Add(field.Name.Substring(1));
                }
            }
            return names.ToArray();
        }
    }
