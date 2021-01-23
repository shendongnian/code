        public static void SetFieldValue(object oRecord, string sName, object oValue)
        {
            PropertyInfo theProperty = null;
            FieldInfo theField = null;
            System.Type oType = null;
            try
            {
                oType = oRecord.GetType();
                // See if the column is a property in the record
                theProperty = oType.GetProperty(sName, BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public, null, null, new Type[0], null);
                if (theProperty == null)
                {
                    theField = oType.GetField(sName, BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public);
                    if (theField != null)
                    {
                        theField.SetValue(oRecord, Global.ValueFromDB(oValue, theField.FieldType.Name));
                    }
                }
                else
                {
                    if (theProperty.CanWrite)
                    {
                        theProperty.SetValue(oRecord, Global.ValueFromDB(oValue, theProperty.PropertyType.Name), null);
                    }
                }
            }
            catch (Exception theException)
            {
                // Do something useful here
            }
       }
