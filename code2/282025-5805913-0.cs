    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("ID", typeof(Int32));
    dataTable.Columns.Add("Geom", typeof(SqlGeometry));
    
    dataTable.Rows.Add(1, SqlGeometry.STGeomFromText("POINT('20,20')"));
    dataTable.Rows.Add(2, SqlGeometry.STGeomFromText("POINT('40,25')"));
    dataTable.Rows.Add(3, SqlGeometry.STGeomFromText("POINT('60,30')"));
    
    SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection);
    sqlBulkCopy.DestinationTableName = "MySpatialDataTable";
    sqlBulkCopy.WriteToServer(dataTable);
