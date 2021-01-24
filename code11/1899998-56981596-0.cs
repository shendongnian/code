 c#
var personRoles = DbContext.Persons_Roles.Where(p=>p.ID_ROLE == 2).ToList();
DbContext.Persons_Roles.RemoveRange(personRoles);
var role = DbContect.Roles.Single(a=>a.ID==2);
DbContext.Roles.Remove(role);
DbContext.SaveChanges();
