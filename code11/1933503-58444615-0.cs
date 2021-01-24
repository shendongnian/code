        [Consumes("application/xml")]
        [Produces("application/xml")]
        [HttpPost("Test")]
        public IActionResult Test([FromBody] TestDTO model)
        {
            return Ok(model);
        }
