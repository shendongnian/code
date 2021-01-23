    var clause = PredicateBuilder.False<HybridGroupUser>();
    clause = clause.Or(u => u.GroupUser.gid.Equals(0);
    foreach (int i in AddedUsers) {
        int tmp = i;
        clause = clause.Or(u => u.User.uid.Equals(tmp));
    }
    var usersInGroup = (from u in db.Users
                        join gusr in db.GroupUser
                            on u.uid equals gusr.uid
                            into ug
                        from gusr in ug.DefaultIfEmpty()
                        select new HybridGroupUser {
                           User = u, 
                           GroupUser = gusr
                        }).Where(clause);
