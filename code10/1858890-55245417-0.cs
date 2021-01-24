    services.AddAuthentication()
    	.AddFacebook(options =>
    	{
    		options.AppId = "";
    		options.AppSecret = "";
    	});
    
    services.AddIdentity<IdentityUser, IdentityRole>()
    	.AddEntityFrameworkStores<MyDbContext>();
