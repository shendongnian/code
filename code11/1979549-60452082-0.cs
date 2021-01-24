    [HttpGet]
    public IActionResult<IEnumerable<User>> GetAll()
    {
        try
        {
            return Ok(userRepository.GetAll());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.InnerException.Message);
        }
    }
