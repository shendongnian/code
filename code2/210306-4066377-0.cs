    [HttpGet]
    public ActionResult CreatePost( int topicId ) {
        PostModel pm = _manager.CreateDefaultPost();
        pm.TopicID = id;
        return PartialView( "CreatePost", pm );
    }
