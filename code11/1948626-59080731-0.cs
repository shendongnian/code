    using Microsoft.EntityFrameworkCore;
    public async Task<bool> CreateClaims(AddClaimsDataDto claimParams)
    {
    	Matter matter;
    
    	matter = await _autoContext.Matters
    		.Include(m => m.Claims)								//Using eager loading here
    		.Where(m => m.MatterNumber == claimParams.Matter)
    		.FirstOrDefaultAsync();
    
    	if (matter == null) 
    	{
    		matter = new Matter 
    		{ 
    			MatterNumber = claimParams,
    			Claims = new List<Claim>()						//Initialize the list here
    		};
    	}
    
    	foreach(var trustName in claimParams.Names) 
    	{
    		var claim = new Claim();
    		matter.Claims.Add(claim);
    	}
    
    	_autoContext.Matters.Add(matter);
    	await _autoContext.SaveChangesAsync();
    
    	return true;
    }
