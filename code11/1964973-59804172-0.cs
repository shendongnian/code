    [HttpGet]
        public IActionResult GetUsers()
        {
            using (var context = new ProjectContext())
            {
                var MyEntity = context.User.ToList();
                return Ok(MyEntity); 
            }
        }
