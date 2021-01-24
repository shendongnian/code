private DataView CreateExhaustionDataView()
{
    DataTable dt = BuildFufillmentDataTable();
    DataView dv = new DataView(dt, "", "Department,Date", DataViewRowState.CurrentRows);
    DataTable result = dv.ToTable(true, "Department", "Date", "Remaining");
    /*for (int i= result.Rows.Count-1; i >= 0; i--)
    {
        if (result.Rows.Count > 0)
        {
            var firstrow = result.Rows[i];
            if (firstrow["Remaining"] != DBNull.Value
                && Convert.ToDouble(firstrow["Remaining"]) > 0.0)
            {
                firstrow.Delete();
            }
        }
    }*/ 
    DataView dvresult = new DataView(result, "Remaining <= 0", "Department, Date", DataViewRowState.CurrentRows);
    return dvresult;
}
