c#
List<Claim> claims = new List<Claim>();
var userRoles = await _userManager.GetRolesAsync(user);
//you could change this to use async and await
//var roles = await _roleManager.Roles.Where(a => userRoles.Contains(a.Name)).ToListAsync();
var roles = _roleManager.Roles.Where(a => userRoles.Contains(a.Name)).ToList();
foreach (var role in roles)
{
	claims.AddRange(await _roleManager.GetClaimsAsync(role));
}
return claims;
