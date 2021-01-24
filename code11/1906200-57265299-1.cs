    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAsync([FromQuery(Name = "userTypeName")]string userTypeName) {
        var result = await ctx.User
            .Include(x => x.UserType)
            .Where(x => x.UserType.Name.ToLower() == UserTypeName.ToLower())
            .ToListAsync();
        if (result == null) return BadRequest();
        return result;
    }
