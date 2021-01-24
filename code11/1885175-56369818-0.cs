    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    List<string> serverNamesList = new List<string>();
    
    OleDbDataAdapter dtAdapter = new OleDbDataAdapter();
    DataTable serverNamesDataTable = new DataTable();
    
    //populate data table
    dtAdapter.Fill(serverNamesDataTable, Dts.Variables["User::ObjectVariable"].Value);
    
    foreach (DataRow dr in serverNamesDataTable.Rows)
    {
        //either access server names from column index 0 of DataRow or add to list
        serverNamesList.Add(dr[0].ToString()); 
    }
