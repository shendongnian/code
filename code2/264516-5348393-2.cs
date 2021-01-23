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
 
