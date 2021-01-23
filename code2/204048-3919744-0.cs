    <asp:gridView id="control" OnDataBound="DataBound" [...]
    protected void DataBound(object sender, EventArgs e)
        {
            control.Visible = control.Rows.Count>0;
        }
