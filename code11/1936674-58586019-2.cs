        public class TicketsController : Controller
        {
            private readonly ApplicationDbContext _context;
            private readonly UserManager<IdentityUser> _userManager;
            public TicketsController(ApplicationDbContext context
                , UserManager<IdentityUser> userManager)
            {
                _context = context;
                _userManager = userManager;
            }
            // GET: Tickets
            public async Task<IActionResult> Index()
            {
                var applicationDbContext = _context.Tickets.Include(t => t.IdentityUser);
                return View(await applicationDbContext.ToListAsync());
            }
            // GET: Tickets/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var ticket = await _context.Tickets
                    .Include(t => t.IdentityUser)
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (ticket == null)
                {
                    return NotFound();
                }
                return View(ticket);
            }
            // GET: Tickets/Create
            public IActionResult Create()
            {
                ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
                return View();
            }
            // POST: Tickets/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("ID,Klant,Applicatie,Onderwerp,Omschrijving,Datum,Status,IdentityUserId")] Ticket ticket)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(ticket);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", ticket.IdentityUserId);
                return View(ticket);
            }
            // GET: Tickets/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var ticket = await _context.Tickets.FindAsync(id);
                if (ticket == null)
                {
                    return NotFound();
                }
                ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", ticket.IdentityUserId);
                return View(ticket);
            }
            // POST: Tickets/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("ID,Klant,Applicatie,Onderwerp,Omschrijving,Datum,Status,IdentityUserId")] Ticket ticket)
            {
                if (id != ticket.ID)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(ticket);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TicketExists(ticket.ID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", ticket.IdentityUserId);
                return View(ticket);
            }
            // GET: Tickets/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var ticket = await _context.Tickets
                    .Include(t => t.IdentityUser)
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (ticket == null)
                {
                    return NotFound();
                }
                return View(ticket);
            }
            // POST: Tickets/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var ticket = await _context.Tickets.FindAsync(id);
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            private bool TicketExists(int id)
            {
                return _context.Tickets.Any(e => e.ID == id);
            }
        }
