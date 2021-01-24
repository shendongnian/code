    public  List<dynamic> ConvertToDynamic(DataTable dt)
        {
            var lstOfDynamic = new List<dynamic>();
            foreach (DataRow row in dt.Rows)
            {
                dynamic dyn = new  System.Dynamic.ExpandoObject();
                foreach (DataColumn col in dt.Columns)
                {
                    var dic = (IDictionary<string, object>)dyn;
                    dic[col.ColumnName] = row[col];
                }
                lstOfDynamic.Add(dyn);
            }
            return lstOfDynamic;
        }
