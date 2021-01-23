    DataTable myDataTable = new DataTable();
            DataColumn PartNumber = new DataColumn("PartNumber");
            DataColumn RequiredQuantity = new DataColumn("RequiredQuantity");
            myDataTable.Columns.Add(PartNumber);
            myDataTable.Columns.Add(RequiredQuantity);
    
            DataRow dataRowPN1 = myDataTable.NewRow();
            DataRow dataRowPN2 = myDataTable.NewRow();
            DataRow dataRowPN3 = myDataTable.NewRow();
          
    
            dataRowPN1["PartNumber"] = "A";
            dataRowPN2["PartNumber"] = "B";
            dataRowPN3["PartNumber"] = "C";
            dataRowPN1["RequiredQuantity"] = "2";
            dataRowPN2["RequiredQuantity"] = "1";
            dataRowPN3["RequiredQuantity"] = "3";
            myDataTable.Rows.Add(dataRowPN1);
            myDataTable.Rows.Add(dataRowPN2);
            myDataTable.Rows.Add(dataRowPN3);
            int  i = myDataTable.Rows.Count;
    
            DataTable joinDataTable = new DataTable();
            DataColumn SerialNumber = new DataColumn("SerialNumber");
            DataColumn JoinPartNumber = new DataColumn("PartNumber");
            joinDataTable.Columns.Add(SerialNumber);
            joinDataTable.Columns.Add(JoinPartNumber);
            foreach (DataRow dr in myDataTable.Rows)
            {
                for (int count = 1; count <= Convert.ToInt16(dr["RequiredQuantity"]); count++)
                {
                    DataRow joindataRow = joinDataTable.NewRow();
                    joindataRow["SerialNumber"] = count.ToString().Trim();
                    joindataRow["PartNumber"] = dr["PartNumber"].ToString().Trim();
                    joinDataTable.Rows.Add(joindataRow);
                }
            }
            Response.Write(joinDataTable.Rows.Count);  
