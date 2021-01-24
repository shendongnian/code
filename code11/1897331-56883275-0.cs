     var posts = new List<BlogDetails>();
        posts.Add(
        new BlogDetails {
            Id = 1,
            Author = "Charles",
            Title = "Finding Charles",
            Body = "This is a great blog post",
            PostedOn = DateTime.Now
        });
     ViewBag.listOfItems =  new SelectList(posts, "Id", "Author");
     return View();
