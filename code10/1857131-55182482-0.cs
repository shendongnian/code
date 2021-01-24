        [HttpGet("{id}/details")]
        public ActionResult<string> GetDetails(int id)
        {
            HttpContext.Items.Add("custom property2", id);
            return "value";
        }
