        public static void FindLongStrings(object testObject)
        {
            foreach (PropertyInfo propInfo in testObject.GetType().GetProperties())
            {
                foreach (ColumnAttribute attribute in propInfo.GetCustomAttributes(typeof(ColumnAttribute), true))
                {
                    if (attribute.DbType.ToLower().Contains("varchar"))
                    {
                        // kinda crude, but it works...
                        string dbType = attribute.DbType.ToLower();
                        int numberStartIndex = dbType.IndexOf("varchar(") + 8;
                        int numberEndIndex = dbType.IndexOf(")", numberStartIndex);
                        string lengthString = dbType.Substring(numberStartIndex, (numberEndIndex - numberStartIndex));
                        int maxLength = 0;
                        int.TryParse(lengthString, out maxLength);
                        string currentValue = (string)propInfo.GetValue(testObject, null);
                        
                        // Do your logging and truncation here
                        if (!string.IsNullOrEmpty(currentValue) && currentValue.Length > maxLength)
                            Console.WriteLine(testObject.GetType().Name + "." + propInfo.Name + " " + currentValue + " Max: " + maxLength);
                    }
                }
            }
        }
