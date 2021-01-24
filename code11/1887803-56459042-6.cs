            public UserInfo convertCSVToEntity(string line, string[] csvMetada)
            {
                var values = line.Split(',');
    
                UserInfo newRecord = ConvertorHelper.ConvertCSVToEntity<UserInfo>(values, csvMetada);
    
                return newRecord;
            }
            public static T ConvertCSVToEntity<T>(string[] csvData, string[] csvMetada) where T : new()
            {
                T returnEntity = new T();
                var properties = returnEntity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
    
                foreach (var eachProperty in properties)
                {
                    var csvAttribute = eachProperty.GetCustomAttribute(typeof(CSVColumn)) as CSVColumn;
                    if (csvAttribute != null)
                    {
                        int csvIndex = Array.IndexOf(csvMetada, csvAttribute.ImportName);
                        if (csvIndex > -1)
                        {
                            var csvValue = csvData[csvIndex];
    
                            object setValue = null;
                            try
                            {
                                setValue = string.IsNullOrEmpty(csvValue) && eachProperty.PropertyType != typeof(string) ? Activator.CreateInstance(eachProperty.PropertyType) : Convert.ChangeType(csvValue, eachProperty.PropertyType, ParseCulture);
                            }
                            catch (Exception e)
                            {
                            }
                    }
                }
    
                return returnEntity;
            }
