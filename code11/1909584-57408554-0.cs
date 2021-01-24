 C#
        public async Task<IActionResult> Post()
        {
            IFormFile file = HttpContext.Request.Form.Files[0];
        }
