services.AddDbContext<AppIdentityDbContext>
     (options => options.UseSqlServer(
          Configuration["Data:Identity:ConnectionString"]    
     )); // could use raw connection string here. This just references appsetting.json
services.AddIdentity<IdentityUser, IdentityRole>(
     opts =>
     {
          opts.Password.RequiredLength = 4;
          opts.Password.RequireDigit = false;
          opts.Password.RequireUppercase = false;
          opts.Password.RequireNonAlphanumeric = false;
     })
     .AddEntityFrameworkStores<AppIdentityDbContext>();
// unsure, but these might be necessary
services.AddMemoryCache();
services.AddSession();
- In Configure():
app.UseSession(); // only use if session and memory cache are indeed necessary
app.UseIdentity(); // I get a warning to use UseAuthentication(), because this will be replaced in the future, but it works for now
I'm not sure this is what you need but I hope it helps. Good luck!
