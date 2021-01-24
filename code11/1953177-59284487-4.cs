#region Namespaces
using System;
using System.Data;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
using Microsoft.SqlServer.Dts.Runtime.Wrapper;
#endregion
// Add in the appropriate namespaces
using System.Data;
using System.Data.OleDb;
[Microsoft.SqlServer.Dts.Pipeline.SSISScriptComponentEntryPointAttribute]
public class ScriptMain : UserComponent
{
    public override void CreateNewOutputRows()
    {
        // Set up the DataAdapter to extract the data, and the DataTable object to capture those results
        DataTable dt = new DataTable();
        // Copy DataTable from DataSet
        dt = Variables.vResults.DataTable["dtName"];
        // Since we know the column metadata at design time, we simply need to iterate over each row in
        //  the DataTable, creating a new row in our Data Flow buffer for each
        foreach (DataRow dr in dt.Rows)
        {
            // Create a new, empty row in the output buffer
            SalesOutputBuffer.AddRow();
            // Now populate the columns - here are sample names, 
            // have to define it before as columns in Script Source Output
            SalesOutputBuffer.PurchOrderID = int.Parse(dr["PurchOrderID"].ToString());
            SalesOutputBuffer.RevisionNumber = int.Parse(dr["RevisionNumber"].ToString());
            SalesOutputBuffer.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            SalesOutputBuffer.TotalDue = decimal.Parse(dr["TotalDue"].ToString());
        } 
    }
}
Alternative 2. You want to match all rows of C# DataSet to SQL Table (1 C# table row matches 0 or 1 SQL Table rows)
--------------------------------------------------------------------
 High level view on the approach:
 1. Create a dataset object with data and store it in SSIS Object type variable. Script Task will do it.
 2. In DataFlow Script Source - read rows from the variable.
 3. Then - create a Lookup with **Partial Cache** and define SQL query to your table. You can create a **No Cache** Lookup if IDs in C# table are unique. Define match condition and columns needed from SQL Table.
 4. Save result at some Destination
Bad Alternative - 1-many match with row multiplication
----------------------------------------------------
Example - row from C# table can match several SQL table rows and you have to output several rows in this case.
 High level view on the approach:
 1. Create a dataset object with data and store it in SSIS Object type variable. Script Task will do it.
 2. In DataFlow Script Source - read rows from the variable. Sort it by ID.
 3. Ad another Data Source where reading SQL Table, ordered by ID in the same direction.
 4. Do a SSIS Merge Join
 5. Save results to some destination
The bad thing about this scenario is that it may require a lot of RAM to do Sort and Merge Join transformations.
