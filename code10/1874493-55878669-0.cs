    public ActionResult Index()
            {
                // Preselect items with id 1 and 3
                var selectedItemIds = new[] { 1, 3 };
        
                var model = new MyViewModel
                {
                    Items = new MultiSelectList(
                        new[] 
                        {
                            // TODO: Fetch from your repository
                            new { Id = 1, Name = "item 1" },
                            new { Id = 2, Name = "item 2" },
                            new { Id = 3, Name = "item 3" },
                        }, 
                        "Id", 
                        "Name", 
                        selectedItemIds
                    )
                };
        
                return View(model);
            }
