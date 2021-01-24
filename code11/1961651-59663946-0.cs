    [HttpPost, ActionName("Upload")]
    public async Task<IActionResult> Upload([FromForm]IFormFile file) {
        try {
            if (file == null)
                return BadRequest("Fejlkonfiguration: Filnavn ikke korrekt");
            // Check if the file is valid.
            if (!Check(file.Name, file.ContentType))
                return BadRequest("Fil ikke gyldig");
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var medie = new Medie {
                Name = file.Name.Trim('\"'),
                ParentId = _imageService.TempFolderGuid,
                ContentLength = file.Length,
                Content = memoryStream.ToArray()
            };
            try {
                var imageId = await _imageService.Medier_InsertMedie(medie);
                //TODO Her skal vi gemme ImageId i Session
                return Json(new {
                    location = $"/api/media/{imageId.Id}.jpg"
                });
            } catch {
                return BadRequest("Kunne ikke gemme billede");
            }
        } catch {
            return StatusCode(500);
        }
    }
