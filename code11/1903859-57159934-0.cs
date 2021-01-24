    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = _dbManager.GetAllJobs();
        return result.Select(x=> new JobDto(){ Id = x.Id, JobName = x.Name ....});
    }
