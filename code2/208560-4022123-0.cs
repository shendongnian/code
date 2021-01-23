        public object DetectType(string stringValue)
        {
            var expectedTypes = new List<Type> {typeof (DateTime), typeof (int)};
            foreach (var type in expectedTypes)
            {
                TypeConverter converter = TypeDescriptor.GetConverter(type);
                if (converter.CanConvertFrom(typeof(string)))
                {
                    try
                    {
                        // You'll have to think about localization here
                        object newValue = converter.ConvertFromInvariantString(stringValue);
                        if (newValue != null)
                        {
                            return newValue;
                        }
                    }
                    catch 
                    {
                        // Can't convert given string to this type
                        continue;
                    }
                   
                }  
            }
            return null;
        }
