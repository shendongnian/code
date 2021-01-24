    public async Task<IActionResult> Products()
        {
            var products =await  _context.Products.ToListAsync();
            return View(products);
        }
        public IActionResult GetPartial(int id)
        {
            var model = _context.Products.Find(id);
            return PartialView("_ItemPartial", model);
        }
