     public static class DataTableMappingtoModel
        {
            /// <summary>
            /// Maps Data Table values to coresponded model propertise
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="dt"></param>
            /// <returns></returns>
            public static List<T> MappingToEntity<T>(this DataTable dt) 
            {
                try
                {
                    var lst = new List<T>();
                    var tClass = typeof (T);
                    PropertyInfo[] proInModel = tClass.GetProperties();
                    List<DataColumn> proInDataColumns = dt.Columns.Cast<DataColumn>().ToList();
                    T cn;
                    foreach (DataRow item in dt.Rows)
                    {
                        cn = (T) Activator.CreateInstance(tClass);
                        foreach (var pc in proInModel)
                        {
                            
                            
                                var d = proInDataColumns.Find(c => string.Equals(c.ColumnName.ToLower().Trim(), pc.Name.ToLower().Trim(), StringComparison.CurrentCultureIgnoreCase));
                                if (d != null)
                                    pc.SetValue(cn, item[pc.Name], null);
                            
                            
                        }
                        lst.Add(cn);
                    }
                    return lst;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
