    public class RoleMenu
    {
        public List<Menu> GetList_Menu_ByRole(Role role)
        {
            using (DBContext db = new DBContext())
            {
                List<RoleMenu> roleMenus = db.RoleMenus.Include(u => u.Role).Include(u => u.Menu).ToList(); //error is here
                List<Menu> roles = new List<Menu>();
                foreach (var eachRoleMenu in roleMenus)
                {
                    if (eachRoleMenu.RoleID == role.ID)
                    {
                        roles.Add(eachRoleMenu.Menu);
                    }
                }
                return roles;
            }
        }
    }
