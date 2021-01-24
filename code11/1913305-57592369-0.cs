    var validPhoneNumber = //your validation logic stuff
    if (!validPhoneNumber ){
       throw new ArgumentException("Invalid phone number");
    }
    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        try{
          bll.AddNumber(person);
        }catch(ArgumentException argumentEx){
           return BadRequest(new {Message = argumentEx.Message});
        }
        // A better approach would be to return the created resource at this point
        return this.NoContent();
    }
