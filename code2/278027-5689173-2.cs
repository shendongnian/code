    public void setProperty(object containingObject, string propertyName, object newValue)
        {
            if (containingObject.GetType().GetProperties().Count(c => c.Name == propertyName) > 0)
            {
                var type = containingObject.GetType().GetProperties().First(c => c.Name == propertyName).PropertyType;
                object val = Convert(type,(string)newValue);
                containingObject.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, containingObject, new object[] { val });
            }
            else
            {
                throw new KeyNotFoundException("The property: " + propertyName + " was not found in: " + containingObject.GetType().Name);
            }
        }
        public object convert(System.Type type, string value)
        {
            return Convert.ChangeType(value, type);
            
        }
