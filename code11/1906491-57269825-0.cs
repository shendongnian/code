    [HttpPost]
    [Route("api/messages")]
    public HttpResponseMessage Update(string retire, [FromBody] message m)
    { 
      if(retire)
       {
           // write the logic of your first endpoint
       }
      else
       {
           // write logic for second
        }
    }
