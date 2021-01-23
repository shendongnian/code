    private void CreateDataTableFromList()
            {
                //supose you have list for X like below
                List<int> x = new List<int>();
                x.Add(1);
                x.Add(2);
                x.Add(3);
                x.Add(4);
    
                //supose you have list for Y like below
                List<int> y = new List<int>();
                y.Add(1);
                y.Add(2);
                y.Add(3);
                y.Add(4);
    
    
                DataTable dt = new DataTable();
                DataColumn dc;
                DataRow dr;
    
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.Int32");
                dc.ColumnName = "TableXVal";
                dt.Columns.Add(dc);
    
                dr = dt.NewRow();
                dr["TableXVal"] = 1;
                dt.Rows.Add(dr);
    
                dr = dt.NewRow();
                dr["TableXVal"] = 2;
                dt.Rows.Add(dr);
    
                dr = dt.NewRow();
                dr["TableXVal"] = 3;
                dt.Rows.Add(dr);
    
                dr = dt.NewRow();
                dr["TableXVal"] = 4;
                dt.Rows.Add(dr);
    
    
                SqlBulkCopy copy = new SqlBulkCopy("Your Connection String");
                copy.DestinationTableName = "NewTableX";
                copy.WriteToServer(dt);
    
    
                dt = new DataTable();
    
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.Int32");
                dc.ColumnName = "TableYVal";
                dt.Columns.Add(dc);
    
                dr = dt.NewRow();
                dr["TableYVal"] = 1;
                dt.Rows.Add(dr);
    
                dr = dt.NewRow();
                dr["TableYVal"] = 2;
                dt.Rows.Add(dr);
    
                dr = dt.NewRow();
                dr["TableYVal"] = 3;
                dt.Rows.Add(dr);
    
                dr = dt.NewRow();
                dr["TableYVal"] = 4;
                dt.Rows.Add(dr);
    
                copy = new SqlBulkCopy("Your Connection String");
                copy.DestinationTableName = "NewTableY";
                copy.WriteToServer(dt); 
            }
