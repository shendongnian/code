    using(var db = new MyDataContext())
            {
                var welcomeSnippet = "test";
                var articles = db.Posts.Include("PostTags").Where(p => p.DateOfPublish <= DateTime.Now).Take(5).ToList();
                
                return View(new HomeViewModel()
                {
                    Articles = articles,
                    WelcomeSnippet = welcomeSnippet
                });
            }
