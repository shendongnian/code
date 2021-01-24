     private string BuildToken(User user)
        {
            var userSerialise = JsonConvert.SerializeObject(user);
            var claims = new[] {
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.UserData, userSerialise)
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(30), 
              signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
      
