    [HttpPost]
    public IActionResult Upload() {
        try {
            var file = Request.Form.Files[0];
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
     
            if (file.Length > 0) {
                var fname = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fname);
                var dbPath = Path.Combine(folderName, fileName);
     
                using (var stream = new FileStream(fullPath, FileMode.Create)) {
                    file.CopyTo(dbPath);
                }
     
                return Ok(new { dbPath });
            }
            else {
                return BadRequest();
            }
        }
        catch (Exception ex) {
            return StatusCode(500, "Internal server error");
        }
    }
