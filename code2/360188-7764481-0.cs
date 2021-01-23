    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        numberFormatDA formatDA = new numberFormatDA();
        DataTable mytable = new DataTable();
        DataColumn formatIDcolumn = new DataColumn("fkNumberFormat");
        DataColumn formatNameColumn = new DataColumn("numberFormat");
        mytable.Columns.Add(formatIDcolumn);
        mytable.Columns.Add(formatNameColumn);
        DataSet ds = new DataSet();
        ds = formatDA.getNumberFormatsDS();
        if ((e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            TextBox txtSite = (TextBox)e.Row.FindControl("txtIDSite");
            DropDownList ddl = (DropDownList)e.Row.FindControl("ddlNumberFormat");
            DataRow[] rows = ds.Tables[0].Select();
            foreach (DataRow row in rows)
            {
                DataRow newrow = mytable.NewRow();
                newrow["fkNumberFormat"] = row["idnumberFormat"];
                newrow["numberFormat"] = row["numberFormat"];
                mytable.Rows.Add(newrow);
            }
            ddl.DataSource = mytable;
            ddl.DataTextField = "numberFormat";
            ddl.DataValueField = "fkNumberFormat";
            int numberFormatID = 0;
            Label lblFormatID = (Label)e.Row.FindControl("numberFormatLabel");
            numberFormatID = Int32.Parse(lblFormatID.Text);
            ddl.SelectedValue = numberFormatID.ToString();
            ddl.DataBind();
        }
    }
