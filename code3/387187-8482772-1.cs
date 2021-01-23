        public static string GetFieldValueForSQL(object oRecord, string sName)
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
                        return theField.GetValue(oRecord).ToString();
                    }
                }
                else
                {
                    return theProperty.GetValue(oRecord, null).ToString();
                }
            }
            catch (Exception theException)
            {
                // Do something with the exception
                return string.empty;
            }
        }
