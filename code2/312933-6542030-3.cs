     protected void btnFileUpload_Click(object sender, EventArgs e)
          {
             FileUpload1.SaveAs(FileUpload1.FileName);
             fileUploadComplete();
          }
    
          private void fileUploadComplete()
          {
             hiddenHyperlink.Attributes["Style"] = string.Empty;
          }
