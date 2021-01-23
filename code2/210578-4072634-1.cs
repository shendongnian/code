    using System.Collections.Generic;
    ...    
    var myDataTable = new DataTable();
    
    foreach (DataRow row in myDataTable.AsEnumerable())
    {
    	var groupColumnValueForCurrentRow = row["Group"];
    }
