    public async Task<ActionResult> CreateUser([FromBody] UserRegisterDto userRegisterDto)
        {
            var user = new User
            {
                FirstName = userRegisterDto.FirstName,
                MiddleName = userRegisterDto.MiddleName,
                LastName = userRegisterDto.LastName,
                Email = userRegisterDto.Email,
                Password = userRegisterDto.Password,
                Phone = userRegisterDto.Phone
            };
            await _context.Users.AddAsync(user);
            
            var role = _context.Roles.Find(userRegisterDto.RoleId);
            UserRole userRole = new UserRole { User = user, Role = role };
            _context.Add(userRole);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Successfully registered." });
        }
