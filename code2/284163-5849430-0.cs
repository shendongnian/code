    placeHolder.Controls.Clear(); //asp:placeholder holds the table structure.
	Table table = new Table();
	table.ID = "table";
	placeHolder.Controls.Add(table); //adding to place holder
	
	TableRow row = new TableRow();
	row.ID ="rowID";
	table.Rows.Add(row); //creating first row for first linq dataset
	
	var nonstop0query = from x in obj select new {x.ID, x.Name, x.Age}; //first linq dataset.
	//Creating cells for the data returned by the nonstop0query
	TableCell cell = new TableCell();
	cell.ID = "cell1";
	row.Cells.Add(cell);
	cell.Text = nonstop0Query[0];
	cell = new TableCell();
	cell.ID = "cell2";
	row.Cells.Add(cell);
	cell.Text = nonstop0Query[1];
	
	cell.ID = "cell3";
	row.Cells.Add(cell);
	cell.Text = nonstop0Query[2];
	
	//Same way can be done for more dataset to bind to row. 
