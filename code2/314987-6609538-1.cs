    this.canvasAuthorizer = new CanvasAuthorizer {
        Permissions = new[] { "user_about_me", "publish_stream", "offline_access", "user_likes", "friends_about_me" }
    };
    
    this.canvasAuthorizer.Authorize();
    
    if (FacebookWebContext.Current.IsAuthorized())
    {
        this.facebookWebClient = new FacebookWebClient(FacebookWebContext.Current);
    
        string requested_Data = HttpContext.Current.Request.Form["signed_request"];
        dynamic decodedSignedRequest = FacebookSignedRequest.Parse(this.facebookApplication, requested_Data);
    
        if (decodedSignedRequest.Data.page != null)
        {
            // Funs Page
            this.IsLike = decodedSignedRequest.Data.page.liked;
        }
        else
        {
            // Application Page
            dynamic likes = this.facebookWebClient.Get("/me/likes");
            foreach (dynamic like in likes.data)
            {
                if (like.id == this.FacebookFanPageID)
                {
                    this.IsLike = true;
                }
            }
        }
    }
