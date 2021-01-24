    public IHttpActionResult Insert(dynamic[] dynamicClass)
        {
            try
            {
                //do something...
                return Ok();
            }
            catch (Exception ex)
            {
                // Otherwise return a 400 (Bad Request) error response
                return BadRequest(ex.ToString());
            }
        }
