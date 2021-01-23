            //--- Get Object Properties
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(targetComponent);
            foreach (var xmlProperty in propertiesFromXML)
            {
                var propertyName = xmlProperty.Name.ToString();
                var propertyDescriptor = props[propertyName];
                if (propertyDescriptor == null)
                {
                    // Property does not exist, create one anyways?
                }
                else
                {
                    propertyDescriptor.SetValue(targetComponent, Convert.ChangeType(xmlProperty.Value, propertyDescriptor.PropertyType));
                }
            }
