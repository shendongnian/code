    public static GridViewRow GetRow(object sender)
    {
        Control c = (Control)sender;
        while ((null != c) && !(c is GridViewRow))
            c = c.NamingContainer;
        return (GridViewRow)c;
    }
    
    /// <summary>
    /// Get the Grid the row is in
    /// </summary>
    /// <param name="row"></param>
    /// <returns></returns>
    public static GridView GetGrid(this GridViewRow row)
    {
        Control c = (Control)row;
        while ((null != c) && !(c is GridView))
            c = c.NamingContainer;
        return (GridView)c;
    }
    
    /// <summary>
    /// Get the ID field value based on DataKey and row's index
    /// </summary>
    /// <param name="sender">Any web-control object in the grid view</param>
    /// <returns></returns>
    public static object GetRowDataKeyValue(object sender)
    {
        try
        {
            GridViewRow row = GetRow(sender);
            GridView grid = row.GetGrid();
            return grid.DataKeys[row.RowIndex].Value;
        }
        catch
        {
            return null;
        }
    }
