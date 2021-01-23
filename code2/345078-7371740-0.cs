    <asp:GridView ID="GrdVw" visible="False" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" OnRowDataBound="GrdVwDataBound">
    
    protected virtual void GrdVwDataBound(GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow)
    	{
    		var imageControl = e.Row.FindControl("currentDocFile") as Image;
    		imageControl.ImageUrl = // Image URL here
    	}
    }
