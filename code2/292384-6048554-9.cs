    protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        if (DtopDownList1.SelectedValue == String.Empty)
        {
            ((SqlCommand)e.Command).Parameters["@status"].Value = DBNull.Value;
        }
    }
