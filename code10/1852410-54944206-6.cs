      public IActionResult Categories()
        {
            var list = new List<Category>();
            for (int i = 0; i < 10; i++)
            {
                 list.Add(new Category(){Id = i, Url = "https://stackoverflow.com", Name = "stackoverflow" });
            }
    
            var selectList = list.Select(x => new SelectListItem() {Value = Url, Text = x.Name})
                .ToList();
            return View(selectList);
        }
