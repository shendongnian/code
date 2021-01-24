    [HttpGet("{parameter:int?}")]
    public async Task<IActionResult> GetAll([FromQuery]int parameter)
    {
        if (parameter == 0)
        {
            return Ok(await Service.GetAll());
        }
        else
        {
            return Ok(await Service.GetAll2(parameter));
        }
    }
