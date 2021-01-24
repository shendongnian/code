    public IList<SecurityLog> SecurityLog { get;set; }
    public async Task OnGetAsync()
    {
        IQueryable<SecurityLog> sort = from s in _context.SecurityLog
                                    .Include(f => f.SecurityLogOfficers)
                                    .ThenInclude(e => e.Officer)
                                        select s;
        SecurityLog = await sort.ToListAsync();
    }
