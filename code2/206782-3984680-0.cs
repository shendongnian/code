    public void btnGo_Click (Object sender, EventArgs e)
    {
      Response.Clear();
      Response.BufferOutput= false;  // for large files
      String ReadmeText= "This is a zip file dynamically generated at " + System.DateTime.Now.ToString("G");
      string filename = System.IO.Path.GetFileName(ListOfFiles.SelectedItem.Text) + ".zip";
      Response.ContentType = "application/zip";
      Response.AddHeader("content-disposition", "filename=" + filename);
      
      using (ZipFile zip = new ZipFile()) 
      {
        zip.AddFile(ListOfFiles.SelectedItem.Text, "files");
        zip.AddEntry("Readme.txt", "", ReadmeText);
        zip.Save(Response.OutputStream);
      }
      Response.Close();
    }
