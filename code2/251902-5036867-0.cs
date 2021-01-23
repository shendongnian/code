    string idFromQueryString = Request.QueryString["id"];
    if (! string.IsNullOrEmpty( idFromQueryString))
    {
      int id = Convert.ToInt32(idFromQueryString );
      Forumfac objfac = new Forumfac();
      foreach (DataRow row in objfac.GetUnderTopics(id).Rows)
      {
      }
    }
