IdentityBuilder builder = services.<b>AddDefaultIdentity</b>&lt;User&gt;(opt =>
{
    ...
})
<b>    .AddRoles&lt;Role&gt;()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores&lt;DataContext&gt;()</b>
    ;
<strike>builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
builder.AddEntityFrameworkStores&lt;DataContext&gt;();
builder.AddRoleValidator&lt;RoleValidator&lt;Role&gt;&gt;();
builder.AddRoleManager&lt;RoleManager&lt;Role&gt;&gt;();
builder.AddSignInManager&lt;SignInManager&lt;User&gt;&gt;();
</strike>
....
<b>services.Configure&lt;CookieAuthenticationOptions&gt;(IdentityConstants.ApplicationScheme,opt=>{
    //if url start with "/api" use jwt instead
    opt.ForwardDefaultSelector = httpContext => httpContext.Request.Path.StartsWithSegments("/api") ? JwtBearerDefaults.AuthenticationScheme : null;
});</b>
services.AddAuthentication(IdentityConstants.ApplicationScheme)
<strike>    .AddCookie(IdentityConstants.ApplicationScheme, options =>
        {
            //if url start with "/api" use jwt instead
            options.ForwardDefaultSelector = httpContext => httpContext.Request.Path.StartsWithSegments("/api") ? JwtBearerDefaults.AuthenticationScheme : null;
        })</strike> 
        .AddJwtBearer(o =>
        {
            ...
        });
