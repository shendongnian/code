    protected void SqlGVDownloadHistory_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        SqlGVDownloadHistory.SelectParameters.Remove("FileName");
        SqlGVDownloadHistory.SelectParameters.Remove("UIDSelect");
        if (ddlSelectDocument.SelectedIndex > 0)
        {
            SqlGVDownloadHistory.SelectParameters.Add("FileName", ddlSelectDocument.SelectedValue);
        }
        if (ddlSelectCCO.SelectedIndex > 0)
        {
            SqlGVDownloadHistory.SelectParameters.Add("UIDSelect", ddlSelectCCO.SelectedValue);
        }
    }
