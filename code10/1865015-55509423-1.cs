        public class CreateModel : PageModel
        {
            private readonly TestRazorContext _context;
            public CreateModel(TestRazorContext context)
            {
                _context = context;
            }
            public IActionResult OnGet()
            {
                RolesOptions = _context.Role.Select(d =>
                        new SelectListItem
                        {
                            Value = d.Id.ToString(),
                            Text = d.Type
                        }).ToList();
                return Page();
            }
            [BindProperty]
            public UserVM User { get; set; }
            public List<SelectListItem> RolesOptions { get; set; }
            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                //create user
                var user = new User {
                    Username = User.Username,
                    //rest properties
                };
                _context.User.Add(user);
                await _context.SaveChangesAsync();
                //set user role
                var userRoles = new List<UserRoles>();
                foreach (var roleId in User.RoleIds)
                {
                    userRoles.Add(new UserRoles
                    {
                        UserId = user.Id,
                        RoleId = roleId
                    });
                }
                _context.UserRole.AddRange(userRoles);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        }
