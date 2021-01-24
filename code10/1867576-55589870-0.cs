        [HttpGet]
        public IHttpActionResult GetCompared([FromQuery]string TeamProject, [FromQuery]string Project, [FromQuery]string branch)
        {
            return Ok();
        }
