    ////saving file in the physical folder;
    
    FileUpload FileUpload1 = file_Image;
    
    string virtualFolder = "~/Resourceimages/";
    
    string physicalFolder = HostingEnvironment.MapPath(virtualFolder);
    
    string PhotoName = ((string)Session["UserName"] + (string)Session["UserSurname"]);
    
    FileUpload1.SaveAs(physicalFolder + PhotoName + FileUpload1.FileName);
    
    string location = virtualFolder + PhotoName + FileUpload1.FileName;
    
    webservice.UpdateResourceImage((int)Session["UserID"], location);
    
    lbl_Result.Text = "Your file " + FileUpload1.FileName + " has been uploaded.";
    
    Image1.Visible = true;
    Image1.ImageUrl = location;
