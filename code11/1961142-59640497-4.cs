    [BindProperty]
    public SecurityLog SecurityLog { get; set; }
    public List<SecurityLogOfficer> SecurityLogOfficers { get; set; } = new List<SecurityLogOfficer>();
    [BindProperty]
    public int[] SelectedOfficerIds { get; set; }
    public async Task<IActionResult> OnPostAsync()
        {
            _context.SecurityLog.Add(SecurityLog);
            foreach (var id in SelectedOfficerIds)
            {
                var item = new SecurityLogOfficer()
                {
                    SecurityLog = SecurityLog,
                    Officer = await _context.Officer.FirstOrDefaultAsync(s => s.ID == id),
                };
                SecurityLogOfficers.Add(item);
            }
            _context.SecurityLogOfficer.AddRange(SecurityLogOfficers);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
