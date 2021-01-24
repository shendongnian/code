    public class ProfileService : IProfileService
    {
    	public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    	{
    		if (context.Caller == IdentityServerConstants.ProfileDataCallers.UserInfoEndpoint)
    		{ 
    			//custom logic to add requested claims 
    			context.AddRequestedClaims(claims);
    		}
    	}
    }
