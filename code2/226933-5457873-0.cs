    foreach (Google.GData.Client.IExtensionElementFactory  property in  googleEvent.ExtensionElements)
            {
                ExtendedProperty customProperty = property as ExtendedProperty;
                if (customProperty != null)
                    genericEvent.EventID = customProperty.Value;                
            }
