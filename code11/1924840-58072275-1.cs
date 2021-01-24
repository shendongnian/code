    public IActionResult OnGet()
        {
            var Clients = from c in _context.Clients
                          orderby c.ClientName
                          select c;
            ClientList = Clients.Select(x => new SelectListItem
            {
                Text = x.ClientName,
                Value = x.id.ToString()
            }).ToList();
             
            return Page();
        }
        [BindProperty]
        public Project Project { get; set; }
        [BindProperty]
        public List<SelectListItem> ClientList { get; set; }
        
