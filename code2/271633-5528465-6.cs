    // Dummy objects so you do not need to load them from DB first. 
    // These objects must exist in database
    var p = new Profile { ProfileId = ... };
    var r = new Role { RoleId = ... };
    
    p.tblRoles.Add(r);
    context.tblProfiles.Attach(p);
    context.tblRoles.Attach(r);
    p.tblRoles.Remove(r);
    // another approach: 
    // context.ObjectStateManager.ChangeRelationshipState(p, r, x => x.tblRoles, EntityState.Deleted);
    
    context.SaveChanges();
