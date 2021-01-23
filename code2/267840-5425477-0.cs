    protected void UploadButton_Click(object sender, EventArgs e)
    {
      string theUserId = Session["UserID"].ToString().Trim(); // add Trim()
      if (FileUploadControl.HasFile && !String.IsNullOrEmpty(theUserId)) // add test
      {
        try
        {
          string filename = Path.GetFileName(FileUploadControl.FileName);
          Console.WriteLine(filename);
          string filepath = string.Format("~/userdata/{0}/uploadedimage/", theUserId);
          Console.WriteLine(filepath );
          string mapPath = Server.MapPath(filepath);
          Console.WriteLine(mapPath );
          FileUploadControl.SaveAs(mapPath + filename);
          StatusLabel.Text = "Upload status: File uploaded!";
        }
        catch (Exception ex)
        {
          StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
        }
      }
    }
