    [Route("[action]")]
    public async Task<ActionResult<int>> GetEmployeeByEmpCode([FromBody]List<Employee> emp)
    {
        
        return Ok(1);
    }
