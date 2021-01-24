    [AllowAnonymous]
    [HttpGet("Download/{id}")]
    public async Task<IActionResult> Download(long? id)
    {
        var attachment = await appService.Download(id);
        return new FileContentResult(attachment.File, 
            MimeTypeMap.GetMimeType(attachment.FileExtension))
        {
            FileDownloadName = $"{attachment.NomeFile}.{attachment.FileExtension}"
        };
    }
