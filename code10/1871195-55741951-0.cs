        public void MakeDataTable(){
    	DataTable myTable;
        DataRow myNewRow; 
        // Create a new DataTable.
        myTable = new DataTable("My Table");
    	//ADDING DATETIME COLUMN
    	DataColumn colDateTime = new DataColumn("DateTimeCol");
        colDateTime.DataType = System.Type.GetType("System.DateTime");
        myTable.Columns.Add(colDateTime);
    	//ADDING ROW TO DATA-Table
    	myNewRow = myTable.NewRow();
    	myNewRow["DateTimeCol"] = System.DateTime.Now;
    	myTable.Rows.Add(myNewRow);
    }
