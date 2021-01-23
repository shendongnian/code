    //Assume yourobjectA and yourobjectB have already been instantiated and populated.
    
    //loop throught he properties and compare
    //they should all be set the same as the previous instance
                PropertyInfo[] propertiesA = yourobjectA.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                PropertyInfo[] propertiesB = yourobjectB.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
    
               
                int count = oldProperties.Length;
    
                for (int i = 0; i < count; i++)
                {
                    if ((propertiesA [i].CanRead) && (propertiesB [i].CanRead))
                    {
                        if (propertiesA [i].PropertyType == typeof(String))
                        {
                            object oldStringValue = (string)propertiesA[i].GetValue(yourobjectA, null);
                            object newStringValue = (string)propertiesB[i].GetValue(yourobjectB., null);
                            if(oldStringValue != newStringValue )
    			    {
    				//Do something
    			    }
                        }
    
                        if (propertiesA [i].PropertyType == typeof(Boolean))
                        {
                            object oldBoolValue = (bool)propertiesA [i].GetValue(yourobjectA, null);
                            object newBoolValue = (bool)propertiesB [i].GetValue(yourobjectB., null);
                            if(oldBoolValue != newBoolValue)
    			    {
    				//Do something
    			    }
                        }
                    }
                }
