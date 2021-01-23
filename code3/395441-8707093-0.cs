    void Begin_Request(object sender, EventArgs e)
    {
        //Protect /images/ folder for all requests
        if (Request.FilePath.Contains("images"))
        {
            YourUser user = Session["user"];
                
            if(user == null) {
                Server.Transfer("404.aspx"); //Folder not public
            }
    
            if (!Request.FilePath.Contains("images/" + user.userID.toString())){
                Server.Transfer("404.aspx"); //This is not current user's image folder
            }
                
        }
    }
