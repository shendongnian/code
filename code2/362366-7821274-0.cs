    protected void Gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int selectedRowIndex = Convert.ToInt32(e.CommandArgument);
        var row = Gv.Rows[selectedRowIndex ];
        var btn = row.FindControl("LinkButton1") as LinkButton;
        if(btn != null)
        {
           btn.visible = false;
        }
    
    }
