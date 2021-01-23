        public YourConstructor()
        {
            LoadDefaults();
        }
        public void LoadDefaults()
        {
            //Iterate through properties
            foreach (var property in GetType().GetProperties())
            {
                //Iterate through attributes of this property
                foreach (Attribute attr in property.GetCustomAttributes(true))
                {   
                    //does this property have [DefaultValueAttribute]?
                    if (attr is DefaultValueAttribute) 
                    {
                        //So lets try to load default value to the property
                        DefaultValueAttribute dv = (DefaultValueAttribute)attr;
                        try
                        {
                            //Is it an array?
                            if (property.PropertyType.IsArray)
                            {
                                //Use set value for arrays
                                property.SetValue(this, null, (object[])dv.Value); 
                            }
                            else
                            {
                                //Use set value for.. not arrays
                                property.SetValue(this, dv.Value, null);
                            }
                        }
                        catch (Exception ex)
                        {
                            //eat it... Or maybe Debug.Writeline(ex);
                        }
                    }
                }
            }
        }
