        public void Add(dynamic v)
        {
            Type type = v.GetType();
            string className = type.Name;
            bool hasNameProperty = type.GetProperty("Name") != null;
            if (hasNameProperty)
            {
                string name = v.Name;
            }
        }
        public void Add2(object o)
        {
            Type type = o.GetType();
            string className = type.Name;
            PropertyInfo nameProperty = type.GetProperty("Name");
            if (nameProperty != null)
            {
                string name = (string)nameProperty.GetValue(o);
            }
        }
