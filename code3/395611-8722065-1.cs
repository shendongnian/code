    protected void dgTask_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btn = (LinkButton)e.Row.Cells[4].FindControl("lnkBtnEdit");
            
                DropDownList ddl = (DropDownList)e.Row.Cells[4].FindControl("ddlDropDown");
                ddl.DataSource = //give datasource;
                ddl.DataBind();
               
                ddl.Attributes.Add("style", "display:none");
                btn.Attributes.Add("onclick", "return Test('" + ddl.ClientID + "," + btn.ClientID + "');");
            }
        }
