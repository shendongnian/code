    public static class ReportHelper
    {
        public static string ToExcel<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                //table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                if (prop.Attributes[typeof(FGMS.Entity.Extensions.ReportHeaderAttribute)] != null)
                {
                    table.Columns.Add(GetColumnHeader(prop), Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
            }
            //So it seems like when there is only one row of data the headers do not appear
            //so adding a dummy blank row which fixed the issues
            //Add a blank Row - Issue # 1471
            DataRow blankRow = table.NewRow();
            table.Rows.Add(blankRow);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    //row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    if (prop.Attributes[typeof(FGMS.Entity.Extensions.ReportHeaderAttribute)] != null)
                    {
                        row[GetColumnHeader(prop)] = prop.GetValue(item) ?? DBNull.Value;
                    }
                table.Rows.Add(row);
            }
            table.TableName = "Results";
            var filePath = System.IO.Path.GetTempPath() + "\\" + System.Guid.NewGuid().ToString() + ".xls";
            table.WriteXml(filePath);
            return filePath;
        }
        private static string GetColumnHeader(PropertyDescriptor prop)
        {
            return ((FGMS.Entity.Extensions.ReportHeaderAttribute)(prop.Attributes[typeof(FGMS.Entity.Extensions.ReportHeaderAttribute)])).ReportHeaderText;
        }       
    }
