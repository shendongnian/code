    [HttpGet("test1/{username}"), AllowAnonymous]
    public IActionResult GetStuff(string userName)
    {
      return Ok(MemberRepository.GetMember(userName));
    }
