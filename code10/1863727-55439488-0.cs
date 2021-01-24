    [HttpPost("EnterUserDetail")]
    public async Task<ActionResult<RegistrationUser>> postUserDetail( RegistrationUser registrationUser)
    {
        // send one query to database to get the result and include here.
        var ldetails = _context.RegistrationUsers.Include(i => i.ListFriends).SingleOrDefault(c=>c.UserName==registrationUser.UserName && c.Password==registrationUser.Password);
        if (ldetails == null && pdetails == null)
        {
            return NotFound();
        }
            return ldetails;
        }
