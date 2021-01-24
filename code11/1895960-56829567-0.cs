    [Route("Test/{id}/{name}")]
        public async Task<IActionResult> Details(int? id ,string name)
        {
            if (id == null)
            {
                return NotFound();
            }
            var test = await _context.TestTab
                .FirstOrDefaultAsync(m => m.Id == id);
            if (test == null)
            {
                return NotFound();
            }
            return View(test);
        }
