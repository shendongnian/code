    Video v = request.Retrieve<Video>(uri);
    if(v != null)
    {
        Comment c = new Comment();
        c.Content = "asdf";
        request.AddComment(v, c);
    }
    else
    {
         // something went wrong when getting the video...
    }
