    var role = await _userManager.GetRolesAsync(user);
    IdentityOptions _options = new IdentityOptions();
    var tokenDescriptor = new SecurityTokenDescriptor
					{
						Subject = new ClaimsIdentity(new Claim[] {
						new Claim("UserID",user.Id.ToString()),
						new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
					}),
						Expires = DateTime.UtcNow.AddDays(_applicationSettings.Token_Expire_Day),
						SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(
							Encoding.UTF8.GetBytes(_applicationSettings.JWT_Secret)),
							SecurityAlgorithms.HmacSha256Signature)
					};
    var tokenHandler = new JwtSecurityTokenHandler();
    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
    var token = tokenHandler.WriteToken(securityToken);
