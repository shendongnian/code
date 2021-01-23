    if (FacebookWebContext.Current.SignedRequest != null)
    {
      dynamic data = FacebookWebContext.Current.SignedRequest.Data;
      if (data.page != null)
      {
        var pageId = (String)data.page.id;
        var isUserAdmin = (Boolean)data.page.admin;
        var userLikesPage = (Boolean)data.page.liked;
      }
      else
      {
        // not on a page
      }
    }
