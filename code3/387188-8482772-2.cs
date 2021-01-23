        public static void GetAllProperties(object oRecord)
        {
            System.Type oType = null;
            try
            {
                oType = oRecord.GetType();
                PropertyInfo[] cProperties;
                cProperties = oType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (PropertyInfo theProperty in cProperties)
                {
                    if (theProperty.PropertyType.IsClass)
                    {
                        GetAllProperties(theProperty.GetValue(oRecord, null));
                    }
                    else
                    {
                        // use theProperty.GetValue(oRecord, null).ToString();
                    }
                }
            }
            catch (Exception theException)
            {
                // Do something with the exception
            }
        }
