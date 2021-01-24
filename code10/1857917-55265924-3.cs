       if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Level = _context.Levels.Where(x => x.Id == Input.LevelId).FirstOrDefault()
                };
                ...
