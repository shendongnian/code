        [HttpPost]
        public ActionResult Form(Comment feedback)
        {
            if (feedback != null)
            {
                feedback.CommentedOn = DateTime.Now;
                feedback.CommentId += 1;
                if (ModelState.IsValid)
                {
                    BlogPost blogpost = db.BlogPosts.Find(feedback.BlogId);
                    if (blogpost != null)
                        blogpost.NoofComments += 1;
                    db.Entry(blogpost).State = EntityState.Modified;
                    db.Entry(feedback).State = EntityState.Modified;
                    db.Comments.Add(feedback);
                    db.SaveChanges();
                    return PartialView("CommentSuccess", feedback);
                }
            }
            return PartialView("Comment", feedback);
        }
