    public async Task<ActionResult<IEnumerable<User>>> MyController()
    {
        var res = await _userService.GetAll();
       
        if (res == null)
        {
            return NotFound();
        }
        return Ok(res);
    }
