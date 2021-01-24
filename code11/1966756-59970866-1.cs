// use a jwt token that can be verified on another domain
   var token = jsonWebTokenService.GetEncryptedToken(new ClaimsIdentity(GetClaimsList(user.Id)), TimeSpan.FromMinutes(10));
 private IList<Claim> GetClaimsList(string id)
        {
            return new List<Claim>() {
                new Claim(ClaimTypes.Name, id),
                new Claim(ClaimTypes.UserData, id),
                new Claim(ClaimTypes.Role, "ROLESTRING")
            };
        }
From JsonWebTokenService.cs -
public string GetEncryptedToken(ClaimsIdentity subject, TimeSpan timeSpan)
        {
            // setup credentials
            var signingCreds = new SigningCredentials(signatureKey, SecurityAlgorithms.HmacSha256);
            var encryptionCreds = new EncryptingCredentials(encryptionKey,
                SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);
            // claims identity for jwt creation
            var handler = new JwtSecurityTokenHandler();
            var utcNow = DateTime.UtcNow;
            var token = handler.CreateJwtSecurityToken(jwtSettings.Issuer, jwtSettings.Issuer, subject,
                utcNow, utcNow.AddMilliseconds(timeSpan.TotalMilliseconds), utcNow, signingCreds, encryptionCreds);
            return handler.WriteToken(token);
        }
*Note - I manually created the signatureKey and encryptionKey with a separate console application I made that utilized secure/tested encryption libraries such as RNGCryptoServiceProvider() and HMACSHA256() and I stored these values securely in Environment Variables on the server for both domains as well as secrets.json for each project.
The registration link is valid for 10 minutes (lifetime of the JWT).
From a controller on *seconddomain.com*, I verify the JWT -
            var user = await userManager.FindByIdAsync(userId);
            try
            {
                var principal = jsonWebTokenService.ProcessEncryptedToken(code);
                var name = principal.FindFirstValue(ClaimTypes.Name);
                var role = principal.FindFirstValue(ClaimTypes.Role);
                if (name != user.Id || role != "ROLESTRING")
                    throw new ArgumentException("User not found.");
                user.EmailConfirmed = true;
                await userManager.UpdateAsync(user);
                await signInManager.SignOutAsync();
                return RedirectToAction("CompleteRegistration", new { userId = userId, code = code });
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "Failed to confirm email for {UserId}", userId);
                return BadRequest();
            }
Again, from JsonWebTokenService.cs, I validate the JWT -
public ClaimsPrincipal ProcessEncryptedToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                IssuerSigningKey = signatureKey,
                ValidIssuer = jwtSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = jwtSettings.Issuer,
                TokenDecryptionKey = encryptionKey,
                ClockSkew = TimeSpan.Zero
            };
            // throws exceptions if the token is no longer valid
            return tokenHandler
                .ValidateToken(token, validationParameters, out SecurityToken validatedToken);
        }
When the token is successfully validated, the user is redirected to complete their registration.
I hope this helps someone else who might be stuck on a similar issue. There is a ton of information on JWTs if you do your research. But, it took me hours to conjure this one up as there was not much info on using JWTs for email registration verification. JWTs are often used for authentication **AFTER** a user has already entered valid credentials on a site. This solution has provided a way for us to validate email registrations across domains as an alternative to the ASP.NET Core Identity UserManager.
  [1]: https://jwt.io/
