    public async Task<IActionResult> Upload(IFormFile file)
    {
    	if (file == null || file.Length == 0) return BadRequest();
    	using (var ms = new MemoryStream())
    	{
	        file.CopyTo(ms);
		    var img = new Entities.Image
		    {
			    Name = file.FileName,
			    ContentType = file.ContentType,
		        Data = ms.ToArray()
		     };
             await _repo.CreateImage(img);
		     return Ok();
    	}
    }
