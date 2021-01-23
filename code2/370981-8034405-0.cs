        string PropertyThatHasCertainValue(object Value)
        {
            foreach (PropertyInfo property_info in this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (object.Equals(property_info.GetValue(this, null), Value))
                {
                    return property_info.Name;
                }
            }
            return "No property has this value";
        }
