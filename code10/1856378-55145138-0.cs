    [HttpPut("{userId}/Block")]
    public async Task<IActionResult> BlockUser(string userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null || !user.LockoutEnabled || user.LockoutEndDate > DateTime.Now)
        {
            return BadRequest();
        }
        var currentTokens = await _context.PersistedGrants
            .Where(x => x.SubjectId == user.UserId)
            .ToArrayAsync();
        _context.PersistedGrants.RemoveRange(currentTokens);
        var newLockOutEndDate = DateTime.Now + TimeSpan.FromMinutes(_options.LockOutInMinutes);
        user.LockoutEndDate = newLockOutEndDate;
        string updater = User.Identity.Name;
        user.UpdateTime(updater);
        await _context.SaveChangesAsync();
        return NoContent();
    }
