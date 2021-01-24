// Here you use ASCII
IssuerSigningKey = new SymmetricSecurityKey (Encoding.ASCII
                    .GetBytes (Configuration.GetSection ("AppSettings:Token").Value))
// Here you use UTF8
var key = new SymmetricSecurityKey (Encoding.UTF8.GetBytes ("Super secret key"));
Also make sure that yours `Configuration.GetSection ("AppSettings:Token").Value` is same as `"Super secret key"` that you use to create JWT.
**EDIT:**
This is my configuration that works:
// In ConfigureServices
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SigningKey"]));
            services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = signingKey,
                    ValidateAudience = true,
                    ValidAudience = this.Configuration["Token:Audience"],
                    ValidateIssuer = true,
                    ValidIssuer = this.Configuration["Token:Issuer"],
                    RequireExpirationTime = true,
                    RequireSignedTokens = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.FromMinutes(3)
                };
            });
// In token controller
private string GetToken(AppUser user)
{
    var utcNow = DateTime.UtcNow;
    var claims = new Claim[]
    {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString())
        };
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SigningKey"]));
        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        var jwt = new JwtSecurityToken(
            signingCredentials: signingCredentials,
            claims: claims,
            notBefore: utcNow,
            expires: utcNow.AddSeconds(_configuration.GetValue<int>("Token:Lifetime")),
            audience: _configuration["Token:Audience"],
            issuer: _configuration["Token:Issuer"]
        );
    return new JwtSecurityTokenHandler().WriteToken(jwt);
}
Maybe it will help you.
