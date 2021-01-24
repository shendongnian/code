    protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            RoleRequirement requirement)
        {
            var claimsIdentity = (ClaimsIdentity)context?.User.Identity;
            var userGroups = claimsIdentity.Claims
                .Where(x => x.Type.Contains("groupsid", StringComparison.OrdinalIgnoreCase))
                .ToList();
            if (userGroups == null || !userGroups.Any())
            {
                return Task.CompletedTask;
            }
            var groupNames = new HashSet<string>();
            foreach (var group in userGroups)
            {
                var groupName = new SecurityIdentifier(group.Value)
                    .Translate(typeof(NTAccount))
                    .ToString();
                groupNames.Add(groupName);
            }
            var userRoles = this.authenticationService.GetRoles(groupNames.ToArray());
            // If the user is an Admin, always allow
            if (userRoles.Contains(Role.Admin))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            var intersectingRoles = Enumerable.Intersect(
                userRoles,
                requirement?.Roles,
                StringComparer.OrdinalIgnoreCase);
            if (intersectingRoles?.Count() > 0)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
