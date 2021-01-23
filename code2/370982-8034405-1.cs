        string PropertyThatHasCertainValue(object Value)
        {
            Type myType = this.GetType();
            while(myType != typeof(object))
            {
                foreach (PropertyInfo property_info in myType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    if (object.Equals(property_info.GetValue(this, null), Value))
                    {
                        return property_info.Name;
                    }
                }
                myType = myType.BaseType;
            }
            return "No property has this value";
        }
