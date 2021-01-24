    public async Task OnGetAsync()
        {
            var employees = from x in _context.Employee
                         select x;
            if (!string.IsNullOrEmpty(SearchString))
            {
                employees = employees.Where(x => x.GetType().GetProperty(SearchField).GetValue(x, null).ToString() == SearchString);
            }
            Employee = await employees.ToListAsync();
        }
