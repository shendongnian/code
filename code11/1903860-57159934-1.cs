    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = _dbManager.GetAllJobs();
        return Ok(result.Select(x=> new JobDto(){ Id = x.Id, JobName = x.Name ....}));
    }
