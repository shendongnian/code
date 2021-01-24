    // using System.IdentityModel.Tokens.Jwt;
    var tokenHandler = new JwtSecurityTokenHandler();
    var jwtSecurityToken = tokenHandler.ReadJwtToken(tokenResponse.AccessToken);
    if (jwtSecurityToken.ValidTo < DateTime.UtcNow.AddSeconds(10))
        Console.WriteLine("Expired");
