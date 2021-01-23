    MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image imgImportedData = (Image) e.Row.FindControl("imgImportedData");
            // Assuming that mySessionVariable isn't already a bool, which it really should be.
            imgImportedData.Visible = bool.Parse(mySessionVariable);
        }
    }
