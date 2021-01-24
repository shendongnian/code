        [HttpPost, ODataRoute("Templates")]
        public IActionResult Insert([FromBody] object value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var template = JsonConvert.DeserializeObject<Template>(value.ToString());
            template.Id = Guid.NewGuid();
            _context.Templates.Add(template);
            _context.SaveChanges();
            return Created(value);
        }
