    protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
    {    
        int xCount = Int32.Parse(gv.Rows[e.NewEditIndex].Cells[2].Text);
    
        if (xCount > 0)
        {        
           string sID = gv.DataKeys[e.NewEditIndex].Value.ToString();
           string queryString = "Default2.aspx?sID=" + sID.ToString();
           string newWin = "var Mleft = (screen.width/2)-(1200/2);
                            var Mtop = (screen.height/2)-(700/2);
                            window.open('" + queryString + "','_blank',
                           'height=600,width=600,
                            status=yes,toolbar=no,scrollbars=yes,menubar=no,
                            location=no,top=\'+Mtop+\', 
                            left=\'+Mleft+\';');";
           ClientScript.RegisterStartupScript(this.GetType(), "pop", newWin, true);    
        }
    }
        
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {                       
            ImageButton img = (ImageButton)e.Row.FindControl("imgbtnEdit");
    
            if (e.Row.Cells[2].Text.Equals("0"))
            {
                img.ImageUrl = "/aspnet/img/stop.gif";
                img.Width = 18;
                img.Height = 18;
                img.Enabled = true;
    
                img.OnClientClick = "";
                img.Attributes["onclick"] = "if(!confirm('...')){return false;};";//open Default3.aspx
            }
        }
    }
