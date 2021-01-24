        [HttpPost]
        <strike>public ActionResult Validate([FromBody] UserLogin user)</strike>
        public ActionResult Validate(UserLogin user)
        {
            var login = _context.UserLogin.Where(s => s.username == user.password);
            ...
        }
