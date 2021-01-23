     Use **"PageIndexChanged"**
    protected void gridView1_PageIndexChanged(object sender, GridViewPageEventArgs e)
            {
                try
                {
                    gridView1.PageIndex = e.NewPageIndex;
                    BindDataGrid();
        ;
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
