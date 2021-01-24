    List<Movie> movieList
    {
        get
        {
            if (Session["movieList"] == null)
            {
                Session["movieList"] = new List<Movie>();
            }
            return Session["movieList"] as List<Movie>;
        }
    }
