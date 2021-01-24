public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        // ...
        app.UseHsts();
    }
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthentication(); // this one first
    app.UseAuthorization(); 
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
My authentication middleware is in an extension method I wrote that is called from the `ConfigureServices()` method in `Startup.cs`:
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            string issuer = configuration.GetValue<string>("Jwt:Issuer");
            string signingKey = configuration.GetValue<string>("Jwt:Key");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);
            services.AddAuthentication(opt=>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options=>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                };
            });
        }
and the token was generated using this extension method:
public static string GenerateApiUserToken(this ApiUser user, IConfiguration configuration)
{
    string signingKey = configuration.GetValue<string>("Jwt:Key");
    string issuer = configuration.GetValue<string>("Jwt:Issuer");
    int hours = configuration.GetValue<int>("Jwt:HoursValid");
    System.DateTime expireDateTime = System.DateTime.UtcNow.AddHours(hours);
    byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);
    SymmetricSecurityKey secKey = new SymmetricSecurityKey(signingKeyBytes);
    SigningCredentials creds = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);
    
    var authClaims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Role, user.RoleName)
    };
    
    JwtSecurityToken token = new JwtSecurityToken(
        issuer:issuer,
        audience: issuer,
        claims: authClaims,
        expires: System.DateTime.UtcNow.AddHours(hours),
        signingCredentials:creds
    );
    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
    string writtenToken = handler.WriteToken(token);
    
    return writtenToken;
}
My Controller class:
[Authorize]
[ApiController]
[Microsoft.AspNetCore.Mvc.Produces("application/json")]
[Microsoft.AspNetCore.Mvc.Route("/[controller]/values", Name="MyController")]
public class MyController : Microsoft.AspNetCore.Mvc.Controller
If the `[Authorize]` tag is on the controller, you should remove any that are on member methods; I left one on the method I was testing and the fix wouldn't work until I removed it.
