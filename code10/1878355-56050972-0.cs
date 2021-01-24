            private IEnumerable<T> ConvertToEnumerable(DataTable dt)
            {
                List<T> ls = new List<T>();
    
                // get all the column names from datatable
                var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();
    
                //dto so all properties should be public
                var dtoProperties = typeof(T).GetProperties(); 
    
                foreach (DataRow row in dt.Rows)
                {
                    // create  a new DTO object
                    var item = new T();
    
                    // for each property of the dto
                    foreach (var property in dtoProperties)
                    {
                        var objPropName = property.Name;
    
                        // I am using the column map dictionary to convert the 
                        // datatable column name into my custom column name
                        // but you can omit this step if your names in DTO 
                        // and datatable columns are same
                        var dbPropName = ColumnMap[property.Name];
                        if (columnNames.Contains(dbPropName))
                        {
                            if (row[dbPropName] != DBNull.Value)
                            {
                                // set the value
                                property.SetValue(item, row[dbPropName], null);
                            }
                        }
                    }
    
                    // add the DTO to the list
                    ls.Add(item);
                }
                return ls;
            }
