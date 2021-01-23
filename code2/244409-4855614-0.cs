    [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
    
            string[] excludedProperties = new string[] { "Username". "Email" };
            var comment = new Comment();
            if (User.Identity.IsAuthenticated)
            {
                comment.Username = User.Identity.Name;
                comment.Email = Membership.GetUser().Email;
            }
    
            TryUpdateModel<Comment>(comment, "", null, excludedProperties, collection.ToValueProvider());
    
            if (ModelState.IsValid)
            {
                this.db.Add(comment);
                return PartialView("Comment", comment);
            }
            else
            {
                //...
            }
        }
