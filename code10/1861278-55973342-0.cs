C#
var validationParameters = new TokenValidationParameters()
{
   RequireExpirationTime = false,  // we can check manually
   ValidateIssuer = true,
   ValidateAudience = true,
   .
   .
   IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
};
            
Then when token is validated, check the expiration time with:
C#
public bool IsExpired(DateTime now)
{
    return JwtSecurityToken.ValidTo > now;
}
I hope this answer will help someone.
