    var mathingMenuUrlMenuAccessCollection = menuaccess.Where(i => i.MenuURL == menuUrl); // return menuaccess items matching given menuurl
    var mathingMenuUrlAndRolesMenuAccessCollection = mathingMenuUrlMenuAccessCollection.Where(i => currentUserRoles.Contains(i.RoleId)); // return menuaccess items matching roles in currentUserRoles
    var filteredMenuAccessCollection = mathingMenuUrlAndRolesMenuAccessCollection.Where(i => i.UserId == userid); // return menuaccess items matching given userid
    // FirstOrDefault will return the first menuaccess item from filteredMenuAccessCollection
    var checkControllerActionRoleUserId = filteredMenuAccessCollection.FirstOrDefault();
