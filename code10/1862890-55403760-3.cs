    public IActionResult Index()
       {
                List<User> users = new List<User>();
                var u = new User() {
                    ID = 1,
                    Name ="a",
                    Surname="aa",
                    Number=111
                };
    
                var u2 = new User()
                {
                    ID = 2,
                    Name = "b",
                    Surname = "bb",
                    Number = 111
                };
                var u3 = new User()
                {
                    ID = 1,
                    Name = "a",
                    Surname = "aa",
                    Number = 111
                };
                users.Add(u);
                users.Add(u2);
                users.Add(u3);
    
                return View(users);
            }
    
            public IActionResult Privacy()
            {
                var uu = new User()
                {
                    ID = 1,
                    Name = "a",
                    Surname = "aa",
                    Number = 111
                };
                ViewBag.User = uu;
                return View();
                }
    }
    }
