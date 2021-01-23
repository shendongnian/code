    using(var db = new MyDataContext())
            {
                var dataLoadOptions = new DataLoadOptions();
                dataLoadOptions.LoadWith<Post>(x => x.PostTags);
                db.LoadOptions = dataLoadOptions;
    
                var welcomeSnippet = "test";
                var articles = db.Posts.Where(p => p.DateOfPublish <= DateTime.Now).Take(5).ToList();
    
                return View(new HomeViewModel()
                {
                    Articles = articles,
                    WelcomeSnippet = welcomeSnippet
                });
            }
