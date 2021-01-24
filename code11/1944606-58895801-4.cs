        [HttpGet()]
        public IActionResult Get([FromServices] CustomContext dbContext)
        {
            if (!string.IsNullOrEmpty(dbContext.CompanyName))
                dbContext.Database.EnsureCreated();
            return Ok();
        }
