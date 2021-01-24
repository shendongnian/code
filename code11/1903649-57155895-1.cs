        [HttpGet("{date:DateRouteConstraint}")]
        public ActionResult<string> Get(DateTime date)
        {
            return Ok();
        }
