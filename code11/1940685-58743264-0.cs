        [HttpGet("{id}")]
        public ActionResult<string> Get([FromRoute]int? id [FromQuery]DateTime? dateTime)
        {
          if(id.HasValue)
          {
            //Do Something with the id
          } 
          else if (dateTime.HasValue)
          {
            //Do Something with the date
          }
        else 
        {
         //return all
        }
     }
