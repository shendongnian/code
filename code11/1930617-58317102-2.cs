    public class IndexModel : PageModel
    {
        private readonly SO1010testContext _context;
        public IndexModel(SO1010testContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var incompletedTeams =  _context.Teams.Include(x => x.Captain)
                .Where(x => x.Status == 0 && (DateTime.Now - x.CreatedAt).Minutes > 30)
                .ToList();
            foreach (var team in incompletedTeams)
            {
                var member = team.Captain;
                var captain = member.Where(m => m.Captain).ToList();
                foreach (var c in captain)
                {
                    team.Status = -1;
                    c.Status = -1;
                }
            }
            await _context.SaveChangesAsync();
            return Page();
        }
    }
    
