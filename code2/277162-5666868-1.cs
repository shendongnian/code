    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
             DataRow dr = ((DataRowView)e.Row.DataItem).Row;
             if (ArrayCollection.Find(dr["KeyColumnName"].ToString()))
    //Dont try to store the index of your Grid and checkbox value, as if the page Index    change your Grid Index will will change. try to store KeyColumnName Value and then compare here and upon bases of set Checkbox = Chcekced
                {
                     CheckBox myCheckBox = (CheckBox)row.FindControl("chkSelect");
                     myCheckBox.Checked = true;
                }
        }
    }
