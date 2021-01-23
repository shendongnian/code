    string devkey = "1"; 
    string username = "2"; 
    string password = "3"; 
    YouTubeRequestSettings a = new YouTubeRequestSettings("test", devkey, username, password); 
    YouTubeRequest request = new YouTubeRequest(a);
        Uri uri = new Uri("b"); 
        Video v = request.Retrieve<Video>(uri); 
        Comment c = new Comment(); 
        c.Content = "asdf"; 
        if (v!= null)
        { 
            request.AddComment(v, c); 
        }
        else
        {
            //Handle the null, try to get the video again, report to user, etc.
        }
