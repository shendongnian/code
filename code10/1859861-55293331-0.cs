    public IActionResult Index()
        {
            //var usersWithRole = _roleManager.Roles.Include(r => r.UserRoles).ThenInclude(u => u.User).OrderBy(r => r.Id).ToList();
            var roleAndUsers = (from r in _context.Role
                         join ur in _context.UserRole
                         on r.Id equals ur.RoleId
                         join u in _context.User
                         on ur.UserId equals u.Id
                         orderby r.Name, u.Email
                         select new UserAndRoleViewModel { Name = r.Name, Email = u.Email, Id = u.Id }).ToList();
            return View(roleAndUsers);
        }
