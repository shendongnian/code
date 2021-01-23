    public List<User> GetUsersStartingWithNonCharacter()
    {
       List<User> _dbUsers = this.GetAllUsers();
       return _dbUsers.Where(p => ((p.FirstName != null && p.FirstName != string.Empty && !char.IsLetter(p.FirstName.ToLower()[0])) || (p.FirstName == null || p.FirstName == string.Empty))).ToList();
    }
    
    public IQueryable<Users> GetAllUsers()
    {
        return from u in _context.pu_Users
                where !u.Is_Deleted
                select new User
                {
                    UserId = u.User_Id,
                    Email = u.Email_Address,
                    FirstName = u.First_Name,
                    LastName = u.Last_Name
                };
    }
