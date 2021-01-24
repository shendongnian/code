        [HttpPost]
        public ActionResult Validate([FromBody] UserLogin user)
        {
            var login = _context.UserLogin.Where(s => s.username == user.password);
            ...        
        }
