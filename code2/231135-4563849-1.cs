        DataTable table = new DataTable("DataTable");
    			for(int i = 1; i < 11; i++){
    				table.Columns.Add(new DataColumn("Column" + i.ToString()));
    			}
    			int j = 0;
    			for (int i = 0; i < 1000; i++) {
    				DataRow newRow = table.NewRow();
    				for (int k = 0; k < table.Columns.Count; k++) {
    					newRow[k] = j++;
    				}				
    				table.Rows.Add(newRow);
    			}
