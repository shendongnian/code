    /// <summary>
            /// Sets a value in an object, used to hide all the logic that goes into
            ///     handling this sort of thing, so that is works elegantly in a single line.
            /// </summary>
            /// <param name="target"></param>
            /// <param name="propertyName"></param>
            /// <param name="propertyValue"></param>
            public static void SetValueFromString(this object target, string propertyName, string propertyValue)
            {
                PropertyInfo oProp = target.GetType().GetProperty(propertyName);
                Type tProp = oProp.PropertyType;
    
                //Nullable properties have to be treated differently, since we 
                //  use their underlying property to set the value in the object
                if (tProp.IsGenericType
                    && tProp.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    //if it's null, just set the value from the reserved word null, and return
                    if (propertyValue == null)
                    {
                        oProp.SetValue(target, null, null);
                        return;
                    }
    
                    //Get the underlying type property instead of the nullable generic
                    tProp = new NullableConverter(oProp.PropertyType).UnderlyingType;
                }
    
                //use the converter to get the correct value
                oProp.SetValue(target, Convert.ChangeType(propertyValue, tProp), null);
            }
