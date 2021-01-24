    [Route("file/")]
    [AuthorizeFunction(AuthFunctions.Schema.Create)]
    [HttpPost]
    [ResponseType(typeof(Schema))]
    public async Task<IActionResult> Create([FromBody] Guid fileId)
    {
         try {
             var result = await _SchemaService.Create(fileId);
             return Created("GetSchema", new { id = result.Id }, result);
         }
         catch (Exception exc){
           if (exc.GetType().FullName == "Your_Exception_Name") 
           {
              // Check your exception name here
           }
       }
    }
    
        
