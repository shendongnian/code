    [HttpPost]
    public ActionResult MyMethod(Post post)
    {
        if (post.ReleaseDate == null)
        {
            post.ReleaseDate = DateTime.Now;
        }
        
        // other stuff
    }
