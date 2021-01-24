    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _config;
        public JwtTokenGenerator(IConfiguration config)
        {
            _config = config;
        }
        //obviously, change User to whatever your user class name is
        public string GenerateToken(User user)
        {
            //Token creation
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };
            // Hashed token Key
            // The token is unique and very secret - if you have the token you are able to create tokens that are verifyable for our backend
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            // Signing credentials 
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            // Security Token DEscripter
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // our claims
                Subject = new ClaimsIdentity(claims),
                // Expiry date - 1 day from create
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            // Token handler
            var tokenHandler = new JwtSecurityTokenHandler();
            // Actual token
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }
    }
