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
