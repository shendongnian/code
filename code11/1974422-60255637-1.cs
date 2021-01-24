    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private IConfiguration _config;
        public ValuesController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public string Get()
        {
            var claim = new[]
            {
                new Claim("userId", "1")
            };
            var data = GetToken("np@hotmail.com", null, claim);
            return data;
        }
        [HttpGet]
        private string GetToken(string userEmail, DateTime? expires, IEnumerable<Claim> claims)
        {    
            var handler = new JwtSecurityTokenHandler();           
            var identity = new ClaimsIdentity(new GenericIdentity(userEmail, "Auth"), claims);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Issuer"],
                SigningCredentials = credentials,
                Subject = identity,
                Expires = DateTime.Now.AddMinutes(120),
                IssuedAt = DateTime.UtcNow
            });
            return handler.WriteToken(securityToken);
        }
    }
