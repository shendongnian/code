    public void CreateTable()
    {
     DataColumn dc = new DataColumn();//Made a new DataColumn to populate above DataTable
                        dc.DataType = System.Type.GetType("System.String");//Defined the DataType inside, this can be [[int]] if you want.
                        dc.ColumnName = "Barkodi";//Gave it a name (important for the custom expression - can only be one word so use underscores if you need multiple words)
    
                        DataColumn dc2 = new DataColumn();
                        dc2.DataType = System.Type.GetType("System.String");
                        dc2.ColumnName = "Emertimi";
    
                        DataColumn dc3 = new DataColumn();
                        dc3.DataType = System.Type.GetType("System.Decimal");
                        dc3.ColumnName = "Sasia";
    
                        DataColumn dc4 = new DataColumn();
                        dc4.DataType = System.Type.GetType("System.Decimal");
                        dc4.ColumnName = "Cmimi";
    
                        DataColumn dc5 = new DataColumn();
                        dc5.DataType = System.Type.GetType("System.String");
                        dc5.Caption = "sds";
    
                        dc5.ColumnName = "TVSH";
    
                        DataColumn dc6 = new DataColumn();
                        dc6.DataType = System.Type.GetType("System.String");
                        dc6.ColumnName = "Total";
                        dc6.Expression = "Cmimi * Sasia";//Multiplying the Price and Quantity DataColumns
    
                        dataTable.Columns.Add(dc);//Add them to the DataTable
                        dataTable.Columns.Add(dc2);
                        dataTable.Columns.Add(dc3);
                        dataTable.Columns.Add(dc4);
                        dataTable.Columns.Add(dc5);
                        dataTable.Columns.Add(dc6);
    
                        dtgartikujt.ItemsSource = dataTable.DefaultView;//Set the DataGrid ItemSource to this new generated DataTable
    }
