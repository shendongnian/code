    [HttpGet]
    [Route("users")]
    public async Task<IActionResult> Get()
    {
        var profLocals = await _unitOfWork.ProfessionalLocalUsers.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<ProfessionalLocalDto>>(profLocals));
    }
    [HttpGet("{id}")]
    [Route("users/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var localUser = await _unitOfWork.ProfessionalLocalUsers.GetAsync(id);
        if (localUser == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<ProfessionalLocalDto>(localUser));
    }
    [HttpGet("{searchText}", Name = "Search")]
    [Route("usersbytext/{id}")]
    public async Task<IActionResult> Get(string searchText)
    {
        var localUsers = await _unitOfWork.ProfessionalLocalUsers.FindAsync(temp => temp.UserID.ToString().Contains(searchText));
        return Ok(_mapper.Map<IEnumerable<ProfessionalLocalDto>>(localUsers));
    }
