using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
public ClaimsPrincipal ValidateRefreshToken(string refreshToken)
{
    try
    {
        var validationParams = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(tokenSecurityKey),
            ValidateLifetime = true
        };
        return new JwtSecurityTokenHandler().ValidateToken
        (
            refreshToken, 
            validationParams, 
            out SecurityToken token
        );
    }
    catch (Exception e)
    {
        Log.Error(e.Message);
        return null;
    }
}
and then
var claims = ValidateRefreshToken(refreshToken);
...
var userIdString = claims.Claims.FirstOrDefault(x => x.Type == "userId")?.Value;
