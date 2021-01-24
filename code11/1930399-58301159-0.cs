    DataTable dt = new DataTable();
                    DataColumn column = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Int32"),
                        AllowDBNull = false,
                        Caption = "Start Day",
                        ColumnName = "startDay",
                        DefaultValue = 0
                    };
                    dt.Columns.Add(column);
    
                    dt.Columns[0].ColumnName = "MyNewColumnName";
                    dt.Columns["MyNewColumnName"].ColumnName = "OtherName";
