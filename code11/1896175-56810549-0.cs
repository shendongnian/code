        [HttpPut]
        [Route("update/{id}")]
        public IHttpActionResult update(int id, [FromBody] Company company)
        {
            int a = id;
            return Ok();
        }
