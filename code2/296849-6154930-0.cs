        //if a user has no roles, there is no way he can possibly edit
        if (roles.Any()) {
          if(roles.Contains(InfoRoles.Administrator.ToString())) {
            return true;
          } else if(parents == null) {
            //If there are no parents, check if this ou is in users list of roles
            return  roles.Contains(ou.DisplayName);
          } else {
            //check to see if any of the roles i have are parents of the current ou
            return  parents.Any(c => roles.Contains(c.DisplayName)); 
          }
