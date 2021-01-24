    [HttpPost]
    public IQueryable<object> Login([FromBody] LoginUser UserCredentails)
    {
       return db.UserLogins.Where(i => i.LoginId.Equals(UserCredentails.Username) && i.Password.Equals(password)).FirstOrDefault();
    }
