    DataAccess.Connection.Close();
    DataAccess.Connection.Open();
    DataAccess.dataAdapter = new SqlDataAdapter(" SELECT sales.qty, sales.ord_date, sales.payterms, stores.stor_name, stores.stor_id, titles.title_id, titles.title, titles.price, (sales.qty * titles.price) AS Total FROM sales INNER JOIN stores ON sales.stor_id = stores.stor_id INNER JOIN  titles ON sales.title_id = titles.title_id", DataAccess.Connection);
    
    DataAccess.dataTable = new DataTable();
    DataAccess.dataAdapter.Fill(DataAccess.dataTable);
    Bind.DataSource = DataAccess.dataTable;
    string temp = DataAccess.dataTable.Rows[0][3].ToString();
    
    Excel.Application xlApp2 = new Excel.Application();
    xlApp2.Visible = true;
    Excel.Workbook Workbook2 = xlApp2.Workbooks.Add(1);
    Excel.Worksheet Worksheet2 = (Excel.Worksheet)Workbook2.Sheets[1];
    
    Worksheet2.Cells[1, 1] = "Sales Report";
    Worksheet2.Cells[3, 1] = temp.ToUpper();
    Worksheet2.Cells[4, 2] = "Order Date";
    Worksheet2.Cells[4, 3] = "Payment Terms";
    Worksheet2.Cells[4, 4] = "Store Name";
    Worksheet2.Cells[4, 5] = "Store ID";
    Worksheet2.Cells[4, 6] = "Title ID";
    Worksheet2.Cells[4, 7] = "Book Title";
    Worksheet2.Cells[4, 8] = "Unit Price";
    Worksheet2.Cells[4, 9] = "Total Price";
    		
    int intCount2 = 5;
    int TotalRec = 0;
    int finecort = 0;
    decimal cost = 0;
    decimal cost1 = 0;
    
    for (int n = 0; n < DataAccess.dataTable.Rows.Count; n++)
    {
    	if (DataAccess.dataTable.Rows[n][3].ToString().Equals(temp))
    	{
    		Worksheet2.Cells[intCount2, "C"] = DataAccess.dataTable.Rows[n][0];
    		Worksheet2.Cells[intCount2, "B"] = DataAccess.dataTable.Rows[n][1];
    		Worksheet2.Cells[intCount2, "D"] = DataAccess.dataTable.Rows[n][3];
    		Worksheet2.Cells[intCount2, "E"] = DataAccess.dataTable.Rows[n][4];
    		Worksheet2.Cells[intCount2, "F"] = DataAccess.dataTable.Rows[n][5];
    		Worksheet2.Cells[intCount2, "G"] = DataAccess.dataTable.Rows[n][6];
    		Worksheet2.Cells[intCount2, "H"] = DataAccess.dataTable.Rows[n][7];
    		Worksheet2.Cells[intCount2, "I"] = DataAccess.dataTable.Rows[n][8];
    		   
    		intCount2++;
    		TotalRec++;
    		finecort++;
    		cost += Convert.ToDecimal(DataAccess.dataTable.Rows[n][8]);
    		cost1 += Convert.ToDecimal(DataAccess.dataTable.Rows[n][8]);
    	}
    	else
    	{
    		Worksheet2.Cells[intCount2, "B"] = ("Number of records in " + temp + " group are" + TotalRec + " and the cost is R" + cost1);
    		TotalRec = 0;
    		cost1 = 0;
    		temp = DataAccess.dataTable.Rows[n][3].ToString();
    		Worksheet2.Cells[intCount2 + 2, "A"] = temp.ToUpper();
    
    		Worksheet2.Cells[intCount2 + 3, "B"] = "Order Date";
    		Worksheet2.Cells[intCount2 + 3, "C"] = "Quantity";
    		Worksheet2.Cells[intCount2 + 3, "D"] = "Store Name";
    		Worksheet2.Cells[intCount2 + 3, "E"] = "Store ID";
    		Worksheet2.Cells[intCount2 + 3, "F"] = "Title ID";
    		Worksheet2.Cells[intCount2 + 3, "G"] = "Book Title";
    		Worksheet2.Cells[intCount2 + 3, "H"] = "Unit Price";
    		Worksheet2.Cells[intCount2 + 3, "I"] = "Total Price";
    			
    		intCount2 += 4;
    	}
    	Worksheet2.Cells.Columns.AutoFit();
    
    }
    	
    Worksheet2.Cells[intCount2, "B"] = ("Number of records in " + temp + " group=" + TotalRec);
    Worksheet2.Cells[intCount2 + 2 ,"A"] = "2013 Sales Report records added upto ";
    Worksheet2.Cells[intCount2 + 2, "B"] = finecort;
    Worksheet2.Cells[intCount2 + 3, "A"] = "Grrand Total of all records ";
    Worksheet2.Cells[intCount2 + 3, "B"] = "R"+cost;
    Worksheet2.Range[Worksheet2.Cells[1, "A"], Worksheet2.Cells[1, "I"]].Merge();
    Worksheet2.Cells.Columns.AutoFit();
    DataAccess.Connection.Close();
