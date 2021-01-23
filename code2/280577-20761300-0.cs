    string AccessToken = "...." // User's access token
    FacebookClient fb = new FacebookClient(AccessToken);    
    dynamic parameters = new ExpandoObject();
    parameters.message = txtNewComment.Text.Trim();    
    dynamic result=fb.Post(HiddenMyPostID.Value+"/comments", parameters);
