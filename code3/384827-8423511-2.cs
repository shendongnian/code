     protected void Button1_Click(object sender, EventArgs e)
     {
    	Label6.Text = ProcessUploadedFile();
     }
    
     private string ProcessUploadedFile()
     {
    	if(!FileUpload1.HasFile)
    		return "You must select a valid file to upload.";
    
    	if(FileUpload1.ContentLength == 0)
    		return "You must select a non empty file to upload.";
    
        //As the input is external, always do case-insensitive comparison unless you actually care about the case.
    	if(!FileUpload1.PostedFile.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
    		return "Only PDF files are supported. Uploaded File Type: " + FileUpload1.PostedFile.ContentType;
    
    	//rest of the code to actually process file.
        return "File uploaded successfully.";
     }
     
