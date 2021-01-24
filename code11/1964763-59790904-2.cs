        public void intersect(DataTable data, DataTable changes)
                {
                    var changeIds = data.AsEnumerable().Intersect(changes.AsEnumerable(), DataRowComparer.Default);
    
    
                    foreach (DataRow row in changeIds)
                    {
                        Response.Write(row["Id"]);
                    }
                }
