    [HttpGet("Get")]
    public JsonResult Get()
    {
      ....       
    }
    [HttpGet("Get/{id}")]
    public JsonResult Get(int id) 
    {
       //....         
    }
     [HttpGet("GetFromQuery")]
    public JsonResult Get([FromQuery]string sortby)
    {
       ....         
    }
