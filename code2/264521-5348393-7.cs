    public void btnUpload_Click(object sender, EventArgs e)
    {
        bool isFileSaved = false;
        string path = "C:\\Images\\..."; // Specify save path here...
        try
        {
          Upload.PostedFile.SaveAs(path);
          isFileSaved = true;
        }
        catch (Exception ex)
        {
          lblError.Text = "File could not be uploaded." + ex.ToString();
          lblError.Visible = true;
        }
     
      if (isFileSaved)
      {
        pnlUpload.Visible = false;
        pnlCrop.Visible = true;
        cropImage.ImageUrl = path;
      }
    } 
