        public static class ExportListToCSV
        {
            public static void CreateCSV<T>(List<T> list, string csvNameWithExt)
            {
                if (list == null || list.Count == 0) return;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader(
                    "content-disposition", string.Format("attachment; filename={0}", csvNameWithExt));
                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                //get type from 0th member
                Type t = list[0].GetType();
                string newLine = Environment.NewLine;
                //gets all columns
                PropertyInfo[] columns = t.GetProperties();
                // skip columns where ScaffoldColumn = false
                // useful to skip column containing IDs for Foreign Keys
                var props = t.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                               .Select(p => new
                               {
                                   Property = p,
                                   Attribute = p.GetCustomAttribute<ScaffoldColumnAttribute>()
                               })
                               .Where(p => p.Attribute == null || (p.Attribute != null && p.Attribute.Scaffold != false))
                               .ToList();
                using (StringWriter sw = new StringWriter())
                {
                    //this is the header row                
                    foreach (var prop in props)
                    {
                        var pi = prop.Property;
                        string columnName = "";
                        // outputs raw column name, but this is not really meaningful for the end user
                        //sw.Write(pi.Name + ",");
                                       
                        columnName = pi.GetDisplayName();
                        sw.Write(columnName + ",");
                    }
                    sw.Write(newLine);
                    //this acts as datarow
                    foreach (T item in list)
                    {
                        //this acts as datacolumn
                        foreach (var prop in props)
                        {
                            var column = prop.Property;
                            //this is the row+col intersection (the value)
                            PropertyInfo info = item.GetType().GetProperty(column.Name);
                            //string value = info.GetValue(item, null);
                            string value = GetDescriptionForComplexObjects(info.GetValue(item, null));                        
                            if (value.Contains(","))
                            {
                                value = "\"" + value + "\"";
                            }
                            sw.Write(value + ",");
                        }
                        sw.Write(newLine);
                    }
                    //  render the htmlwriter into the response
                    HttpContext.Current.Response.Write(sw.ToString());
                    HttpContext.Current.Response.End();
                }
            }
            private static string GetDescriptionForComplexObjects(object value)
            {      
                string desc = "";
                if (             
                    (value != null && !IsSimpleType(value.GetType()))
                    )
                {
                    dynamic dynObject = value;
                    if (dynObject != null)
                    {
                        //using Model Extensions, 
                        //I made sure all my objects have a DESCRIPTION property 
                        //this property must return a string
                        //for an employee object, you would return the employee's name for example
                        //desc = dynObject.DESCRIPTION;
                    }
                }
                else
                {
                    desc = "" + value;
                }
                return desc;
            }
            public static string GetDisplayName(this PropertyInfo pi)
            {
                if (pi == null)
                {
                    throw new ArgumentNullException(nameof(pi));
                }
                return pi.IsDefined(typeof(DisplayAttribute)) ? pi.GetCustomAttribute<DisplayAttribute>().GetName() : pi.Name;
            }
            public static bool IsSimpleType(Type type)
            {
                return
                    type.IsPrimitive ||
                    new Type[] {
                typeof(Enum),
                typeof(String),
                typeof(Decimal),
                typeof(DateTime),
                typeof(DateTimeOffset),
                typeof(TimeSpan),
                typeof(Guid)
                    }.Contains(type) ||
                    Convert.GetTypeCode(type) != TypeCode.Object ||
                    (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && IsSimpleType(type.GetGenericArguments()[0]))
                    ;
            }
        }
    }
