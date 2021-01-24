    [AllowAnonymous]
    [HttpPost]
    [Route("api/ApplicationUser/Register")]
    public async Task<IActionResult> Register([FromBody]ApplicationUserDto userDto)
    {
        //map dto to entity
        var user = _mapper.Map<ApplicationUser>(userDto);
        try
        {
            // save 
            await _userService.Create(user, userDto.Password);
            return Ok();
        }
        catch (AppException ex)
        {
            // return error message if there was an exception
            return BadRequest(new { message = ex.Message });
        }   
    }
