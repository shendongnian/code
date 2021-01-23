    var sid = new SecurityIdentifier(message.SenderId, 0);
    var user = UserPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain), IdentityType.Sid, sid);
    var principal = new GenericPrincipal(
                       new GenericIdentity(user.SamAccountName),
                       user.GetAuthorizationGroups().Select(g => g.SamAccountName).ToArray());
    bool authorized = AuthorizationFactory.GetAuthorizationProvider().Authorize(principal, operation);
