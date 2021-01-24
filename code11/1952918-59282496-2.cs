    // GET: api/Resources
    [HttpGet]
    public async Task<ActionResult<ICollection<Data>>> GetAll()
    {
        return Ok(await Service.GetAll());
    }
    
    // GET: api/Resources/1
    [HttpGet("{parameter:int}")]
    public async Task<ActionResult<Data2>> GetAll([FromRoute]int parameter)
    {
        return Ok(await Service.GetAll2(parameter));
    }
