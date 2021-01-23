    var onlineKeys = Membership.GetAllusers().Cast<MembershipUser>()
                    .Where(u => u.IsOnline)
                    .Select(u => (Guid)u.ProviderUserKey)
                    .ToList();
    
    var onlinePlayers = from p in _db.Players
                        where onlineKeys.Contains(p.userId)
