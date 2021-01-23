        class CoreTransaction
        {
            public void Trim()
            {
                IEnumerable<PropertyInfo> stringProperties =
                    this.GetType().GetProperties()
                    .Where(p => p.PropertyType == typeof(string) && p.CanRead && p.CanWrite);
                foreach (PropertyInfo property in stringProperties)
                {
                    string value = (string)property.GetValue(this, null);
                    value = value.Trim();
                    property.SetValue(this, value, null);
                }
            }
        }
