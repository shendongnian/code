      public ActionResult CurrentPost(int? id)
        {
            SiteContext db = new SiteContext();
            var post = db.Posts.First(p => p.PostId == id);
            return PartialView(post);
        }
