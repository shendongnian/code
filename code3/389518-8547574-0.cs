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
                    else
                    {
                        object[] aAttributes = null;
                        // See if the class type is decorated with the NoUDFs attribute. If so, do not add the attribute.
                        aAttributes = oType.GetCustomAttributes(typeof(NoUDFsAttribute), true);
                        if (aAttributes.Length == 0)
                        {
                            // Otherwise, anything that is not found as a property or a field will be stored as a UDF
                            oRecord.SetUDFValue(sName, oValue);
                        }
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
                // Handle the exception
            }
        }
