    //your code that populates the dataTable 
    
     DataColumn col1 = new DataColumn();
     col1.ColumnName  = "SrNo";
     col1.AutoIncrement = true;
     col1.AutoIncrementSeed = 1;
     col1.AutoIncrementStep = 1;
     
     dataTable.Columns.Add(col1);
    
     for(int i=0;i<dataTable.Rows.Count;i++)
      {
        dataTable.Rows[i]["SrNo"] = i + 1;
      }
     dataGridView1.DataSource = dataTable;
