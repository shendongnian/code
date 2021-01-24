      public IActionResult Test()
        {
            var list = new List<Category>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Category(){Id = i,Url="Your url here", Name = "Your category Name here"});
            }
    
            var selectList = list.Select(x => new SelectListItem() {Value = Url, Text = x.Name})
                .ToList();
            return View(selectList);
        }
