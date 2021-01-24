    [HttpGet("path")]
        [Produces("image/jpeg", "image/webp", "text/plain")]
        public async Task<IActionResult> Get(/*parameters*/)
        {
            if(/*invalid parameters*/)
            {
               return BadRequest("invalid parameters");
            }
            Byte[] image = GetImage();
            return File(image, "image/jpeg");
        }
