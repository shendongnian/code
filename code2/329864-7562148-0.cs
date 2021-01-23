    //Our relational dataset...
    dsBadRowTest dsRelated = new dsBadRowTest();
    
    //The error table will be a non-relational version
    dsBadRowTest.ChildTableDataTable dtErrors = new dsBadRowTest.ChildTableDataTable();
    
    //Add an extra column the error table for extra info
    dtErrors.Columns.Add("ErrorMessage");
    
    //Fill our parent table
    for (Int32 i = 1; i <= 5; i++) {
    	dsRelated.ParentTable.AddParentTableRow(i);
    }
    
    //attempt to fill our child table, with invalid children
    for (Int32 i = 1; i <= 10; i++) {
    	dsBadRowTest.ChildTableRow drNewChild = dsRelated.ChildTable.NewChildTableRow;
    	drNewChild.ForeignKeyColumn = i;
    
    	try {
    		dsRelated.ChildTable.AddChildTableRow(drNewChild);
    	} catch (Data.InvalidConstraintException ex) {
    		//Problem adding...Copy the row for the error table    
    		dsBadRowTest.ChildTableRow drError = dtErrors.NewChildTableRow;
    		foreach (System.Data.DataColumn dc in drNewChild.Table.Columns) {
    			drError(dc.ColumnName) = drNewChild(dc);
    		}
    
    		//Our non-typed extra column will contain the error message
    		drError("ErrorMessage") = ex.Message;
    
    		dtErrors.AddChildTableRow(drError);
    	}
    }
    
    if (dtErrors.Rows.Count > 0) {
    	//Uh oh, we had some bad inserts
    
    	//...do something with the list of errors...
    }
