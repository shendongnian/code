    [HttpGet]
    [Route("releasenotes")]
    public async Task<IActionResult> ReadReleaseNotes()
    {
        var viewPath = Path.GetFullPath(Path.Combine(HostingEnvironment.WebRootPath, $@"..\Views\Home\releasenotes.html"));
        var viewContents = await System.IO.File.ReadAllTextAsync(viewPath).ConfigureAwait(false);
        return Content(viewContents, "text/html");
    }
