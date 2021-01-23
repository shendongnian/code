    protected void Page_Load(object sender, System.EventArgs e) {  
        string ID = Request.QueryString["ImageID"];  
        string Name = Request.QueryString["ImageName"];  
        Label1.Text = "ImageID: "+ ID;  
        Label2.Text = "Image name: "+ Name;  
        Image1.ImageUrl = "~/Images/"+Name+".jpg";  
    }  
