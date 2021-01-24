async function fetchWithCredentials(url, options) {    
    options.headers['Authorization'] = 'Bearer ' + jwtToken;
    var response = await fetch(url, options);
    if (response.ok) {
        return response;
    }
    let flag:boolean=false; //set flag for executing one if statement at a time.
if (response.status == 401 && response.headers.has('Token-Expired')) {
        // refresh the token
        flag=true;  //set flag true.
        //write something as per your requirement.
    } 
if (response.status == 401 && flag==false) {
        **// Only for unauthorized request. You can use this for your problem.**
        //write something as per your requirement.
    } 
}
And most important thing is, You have to use below code in startup.cs.
services.AddCors(context => context.AddPolicy("CustomPolicy", builder =>
{
    builder.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader()
          .WithExposedHeaders("Token-Expired"); ;
}));
In Configure:
app.UseCors("CustomPolicy");
and use below code as it is.
services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "bearer";
    options.DefaultChallengeScheme = "bearer";
}).AddJwtBearer("bearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Configuration["serverSigningPassword"])),
        ValidateLifetime = true,
        ClockSkew = System.TimeSpan.Zero //the default for this setting is 5 minutes
    };
    options.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("Token-Expired", "true");
            }
            return System.Threading.Tasks.Task.CompletedTask;
        }
    };
});
Now, you'll get response on client side.
Hope you'll find your solution. Please let me know for any doubt.
