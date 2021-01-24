        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var types = await _context.DishTypes.ToListAsync();
            var vm = new DishesVM {
                DishTypes = types
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DishesVM vm)
        {
            return Ok(vm);
        }
