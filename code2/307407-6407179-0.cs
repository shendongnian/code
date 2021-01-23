     protected void GridView1_RowDataBond(object source, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btnAlertStatus = (LinkButton)e.Row.FindControl("btnAlertStatus");
    
                    btnAlertStatus.Attributes.Add("onclick", "alert('test'); ");
            }
        }
