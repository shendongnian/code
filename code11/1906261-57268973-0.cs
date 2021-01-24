    using System.IdentityModel.Tokens.Jwt;  // System.IdentityModel.Tokens.Jwt
    using System.Security.Claims;           // Microsoft.Extensions.Identity.Core
    var user = _result.User;
    var sub = user.FindFirstValue(JwtRegisteredClaimNames.Sub);
    // which is actually the same as:
    var sub = user.FindFirstValue("sub");
