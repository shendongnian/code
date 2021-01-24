        [HttpGet, Route("getTest")]
        public IHttpActionResult Get ()
        {
           return Ok(implementationClass.getTest());  // Returns an OkNegotiatedContentResult
        }
