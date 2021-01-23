    var post = _db.Posts.Where(pt => pt.PostID == id).Single();
    var postTags = post.PostTags.Where(pt => pt.PostID == id);
    string tagList = string.Empty;
    
    foreach(var pt in postTags)
    {
         var tag = _db.Tags.Where(t => t.ID == pt.TagID).Single(); 
         tagList += tag.Name + " ";
    }
    TaggingModel model = new TaggingModel(tagList, post);
    return View(model);
