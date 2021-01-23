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
                        return Global.ValueForSQL(theField.GetValue(oRecord), theField.FieldType.Name);
                    }
                    else
                    {
                        UDF oUDF = null;
                        object[] aAttributes = null;
                        // See if the class type is decorated with the NoUDFs attribute. If so, do not get the value.
                        aAttributes = oType.GetCustomAttributes(typeof(NoUDFsAttribute), true);
                        if (aAttributes.Length == 0)
                        {
                            oUDF = oRecord.GetUDF(sName);
                        }
                        if (oUDF != null)
                        {
                            return Global.ValueForSQL(oUDF.Value);
                        }
                        else
                        {
                            return "Null";
                        }
                    }
                }
                else
                {
                    return Global.ValueForSQL(theProperty.GetValue(oRecord, null), theProperty.PropertyType.Name);
                }
            }
            catch (Exception theException)
            {
                // Handle the exception
                return null;
            }
        }
