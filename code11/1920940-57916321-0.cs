    [HttpPost]  
    public async Task<IActionResult> MyPostMethodName(Model model)
        {
            if (!ModelState.IsValid)
            {
            }
            //your post logic
            //...
            //need a  ViewBag.category if you return the same view,
            ViewBag.category = new SelectList(_context.CategoryTbl, "Id", "Name", model.Category);
            return View(product);
        }
