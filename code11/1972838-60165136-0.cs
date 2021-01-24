csharp
public class AuthController : ControllerBase
{
    private static readonly Dictionary<string, string> _userTokens = new Dictionary<string, string> { { "abdul", null } };
    private readonly JwtBearerOptions jwtOpts;
    public AuthController(IOptionsSnapshot<JwtBearerOptions> jwtOpts)
    {
        this.jwtOpts = jwtOpts.Get(JwtBearerDefaults.AuthenticationScheme) ?? throw new Exception("JwtBearerOptions is null!");
    }
    private JwtSecurityToken GenerateToken(IEnumerable<Claim> claims)
    {
        var key = this.jwtOpts.TokenValidationParameters.IssuerSigningKey;
        var signCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var tokeOptions = new JwtSecurityToken(
            issuer: jwtOpts.TokenValidationParameters.ValidIssuer,
            audience: jwtOpts.TokenValidationParameters.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(1),
            signingCredentials: signCredentials
        );
        return tokeOptions;
    }
   ...
