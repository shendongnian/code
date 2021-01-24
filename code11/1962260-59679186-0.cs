c#
List<Claim> claims = new List<Claim>();
var userRoles = await _userManager.GetRolesAsync(user);
var roles = _roleManager.Roles.Where(a => userRoles.Contains(a.Name)).ToList();
foreach (var role in roles)
{
	claims.AddRange(await _roleManager.GetClaimsAsync(role));
}
return claims;
