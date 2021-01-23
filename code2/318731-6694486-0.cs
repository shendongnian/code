    public ActionResult Index(int pageID){
       return View();//the question page
    }
    
    [HttpPost]
    public ActionResult Upvote(int pageID, int messageID){
       //update message votes
       return RedirectToAction("Index", new { @pageID = pageID } );
    }
    
    [HttpPost]
    public ActionResult Downvote(int pageID, int messageID){
       //update message votes
       return RedirectToAction("Index", new { @pageID = pageID } );
    }
    
    [HttpPost]
    public ActionResult PostComment(int pageID, int parentMessageID){
       //add comment to parent message
       return RedirectToAction("Index", new { @pageID = pageID } );
    }
