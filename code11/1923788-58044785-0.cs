    // using System.Collections.Generic;
    // using System.Linq;
    // using System.Security.Claims;
    // This method is available for all authenticated users
    [Authorize]
    public void Delete(int id)
    {
        // Test if current user wants to delete itself
        if (User.FindFirst(ClaimTypes.UserData).Value != id.ToString())
        {
            // Find all roles of the current user.
            var roles = User.FindAll("role").Select(r => r.Value).ToList();
            // A fixed list, ordered by importance
            var allowedRoles = new List<string> { "SuperAdmin", "Admin", "Manager" };
            // Highest role of the current user
            var role = allowedRoles.Intersect(roles).FirstOrDefault();
            // "Registered" user is not allowed to do anything with other users
            if (role == null)
                return;
            // Get the rolename(s) of the target user. Something like this, where
            // _identity is a repository (usermanager?) that has access to the database
            var targetUserRoles = _identity.Where(u => u.Id == id).Roles().Select(r => r.Name).ToList();
            //var targetUserRoles = new List<string> { "Admin" };
            // Highest role of the target user, because you don't want to delete
            // a user that is both Manager and SuperAdmin when you are Admin.
            var targetUserRole = allowedRoles.Intersect(targetUserRoles).FirstOrDefault();
            // Users without a matching role may be deleted
            if (targetUserRole != null)
            {
                // Determine the importance of the role of both
                // the current user and the target user
                var targetIndex = allowedRoles.IndexOf(targetUserRole);
                var index = allowedRoles.IndexOf(role);
                // Index==0 is SuperAdmin
                // Otherwise index of role of targetuser must be higher
                if (index > 0 && targetIndex <= index)
                    return;
            }
        }
        
        // If we got here we can safely delete the user.
        //TO DO: Deletion code
    }
