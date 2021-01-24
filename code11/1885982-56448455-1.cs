    public class SubmoduleAuthorizationHandler : AuthorizationHandler<SubmoduleTypeRequirement>
     {
         protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SubmoduleTypeRequirement submoduleRequirement)
    {
        if (!submoduleRequirement.ActionType.HasValue)
        {
            throw new ArgumentException("No action type provided");
        }
        if (!submoduleRequirement.Type.HasValue)
        {
            throw new ArgumentException("No submodule type provided");
        }
        if (!context.User.HasClaim(uc => uc.Type == submoduleRequirement.Type.ToString()))
        {
            context.Fail();
            return Task.FromResult(0);
        }
          var grantedRights = Convert.ToString(context.User.FindFirst(c => c.Type == submoduleRequirement.Type.ToString()));
         if (grantedRights.Contains(submoduleRequirement.ActionType.ToString()))
          {
            context.Succeed(submoduleRequirement);
          }
          return Task.FromResult(0);
      }
     }
