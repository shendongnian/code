    [HttpPost]
        public async Task<IActionResult> Index(List<int> courseSelectedStatus)
        {
            foreach(var i in courseSelectedStatus)
            {
                var employee = await _context.Employees.Where(e => e.Id == i).FirstOrDefaultAsync();
                employee.isSelected = true;
                _context.Update(employee);
                await _context.SaveChangesAsync();
            }
            //other logic
        }
