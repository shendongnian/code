            // New instance of the control (read the type from the XML and create accordingly)
            var ctrlInstance = new Button();
            // Get a reference to the type of the control created.
            var ctrlType = ctrlInstance.GetType();
            // Dictionary to contain property names and values to set (read from XML)
            var properties = new Dictionary<string, object>();
            foreach (var xmlProp in properties)
            {
                // Get a reference to the actual property in the type
                var prop = ctrlType.GetProperty(xmlProp.Key);
                if (prop != null && prop.CanWrite)
                {
                    // If the property is writable set its value on the instance you created
                    // Note that you have to make sure the value is of the correct type
                    prop.SetValue(ctrlInstance, xmlProp.Value, null);
                }
            }
