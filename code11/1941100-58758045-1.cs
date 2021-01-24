        public void Add(dynamic v)
        {
            Type type = v.GetType();
            bool hasClassNameProperty = type.GetProperty("ClassName") != null;
            if (hasClassNameProperty)
            {
                string className = v.ClassName;
            }
            bool hasNameProperty = type.GetProperty("Name") != null;
            if (hasNameProperty)
            {
                string name = v.Name;
            }
        }
        public void Add2(object o)
        {
            Type type = o.GetType();
            PropertyInfo classNameProperty = type.GetProperty("ClassName");
            if (classNameProperty != null)
            {
                string className = (string)classNameProperty.GetValue(o);
            }
            PropertyInfo nameProperty = type.GetProperty("Name");
            if (nameProperty != null)
            {
                string name = (string)nameProperty.GetValue(o);
            }
        }
