      public static class Hasher
        {
            public static string ToEncrypt<T>(this T value)
            {
                using (var sha256 = SHA256.Create())
                {
                    // Send a sample text to hash.  
                    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value.ToString()));
                    // Get the hashed string.  
                    return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                }
            }
        }
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    
        public DbSet<Users> Users { get; set; }
    //BLL
        public class UsersRepository : IUsersRepository
        {
            private readonly AppDBContext _context;
            public UsersRepository(AppDBContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Users>> GetUsers()
            {
                return await _context.Users.ToListAsync();
            }
    [AllowAnonymous]
            [HttpPost("authenticate")]
            public IActionResult Authenticate([FromBody]UserDto userDto)
            {
                var user = _userService.Authenticate(userDto.Username, userDto.Password);
    
                if (user == null)
                    return BadRequest("Username or password is incorrect");
    
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] 
                    {
                        new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
    
                // return basic user info (without password) and token to store client side
                return Ok(new {
                    Id = user.Id,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Token = tokenString
                });
            }
