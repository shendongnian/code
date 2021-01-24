    public static string GetStringValue(Enum value)
            {
                string output = null;
                try
                {
                    Type type = value.GetType();
    
                    if (_stringValues.ContainsKey(value))
                        output = (_stringValues[value] as StringValueAttribute).Value;
                    else
                    {
                        ////Look for our 'StringValueAttribute' in the field's custom attributes
                        FieldInfo fi = type.GetField(value.ToString());
                        StringValueAttribute[] attrs = fi.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
                        if (attrs.Length > 0)
                        {
                            _stringValues.Add(value, attrs[0]);
                            output = attrs[0].Value;
                        }
    
                    }
                }
                catch (Exception)
                {
                    
                }
    
                return output;
    
            }
