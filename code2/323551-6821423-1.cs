    protected void insertButton_Click(object sender, EventArgs e)
    {
        HttpFileCollection hfc = Request.Files;
        for (int i = 0; i < hfc.Count; i++)
        {
          HttpPostedFile hpf = hfc[i];
        
          // Make a unique blob name
          string extension = System.IO.Path.GetExtension(hpf.FileName);
    
          // Create the Blob and upload the file
          var blob = _BlobContainer.GetBlobReference(Guid.NewGuid().ToString() + extension);
          blob.UploadFromStream(hpf.InputStream);
    
          // Set the metadata into the blob
          blob.Metadata["FileName"] = fileNameBox.Text;
          blob.Metadata["Submitter"] = submitterBox.Text;
          blob.SetMetadata();
    
          // Set the properties
          blob.Properties.ContentType = hpf.ContentType;
          blob.SetProperties();
        }
    }
