    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (GridView1.EditIndex == -1) return;
        FileUpload fileUpLoad = GridView1.Rows[GridView1.EditIndex].FindControl("FileUpload1") as FileUpload;
        string fileName = fileUpLoad.FileName;
        TextBox txtImage = GridView1.Rows[GridView1.EditIndex].FindControl("txtImage") as TextBox;
        if (fileUpLoad != null && fileUpLoad.HasFile)
        {
            txtImage.Text = fileUpLoad.FileName;
        }
        else
        {
            txtImage.Text = txtImage.Text;
        }
        
    }
