        public List<T> ConvertDatatableToList<T>(DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();
                foreach (var row in table.AsEnumerable())
                {
                    var obj = createObject<T>(row);
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw null;
            }
        }
        public T createObject<T>(DataRow row) where T : class, new()
        {
            T obj = new T();
            //itterating over the properties defined in the class
            foreach (var prop in obj.GetType().GetProperties())
            {
                try
                {
                    //checking if the property is a generic type and if it is Nullable(?)
                    if (prop.PropertyType.IsGenericType && prop.PropertyType.Name.Contains("Nullable"))
                    {
                        if (!string.IsNullOrEmpty(row[prop.Name].ToString()))
                            prop.SetValue(obj, Convert.ChangeType(row[prop.Name], Nullable.GetUnderlyingType(prop.PropertyType), null));
                    }
                    else
                        prop.SetValue(obj, Convert.ChangeType(row[prop.Name], prop.PropertyType), null);
                }
                catch
                {
                    continue;
                }
            }
            return obj;
        }
