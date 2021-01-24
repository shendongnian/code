    [HttpPost]
    public IActionResult Post([FromBody]User user)
    {
        var response = new User
        {
            Id = 3,
            Name = "Sandy"
        };
        return Ok(response);
    }
