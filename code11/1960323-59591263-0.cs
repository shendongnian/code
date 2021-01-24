public async Task<IActionResult> Download(string id)
{
    var project = await this.service.GetById(id).ConfigureAwait(false);
    if (project == null)
    {
        return this.NotFound($"Project [{id}] does not exist");
    }
    var file = new FileInfo(project.DownloadLocation);
    this.Response.Headers.Add("Content-Length", file.Length.ToString() );
    return this.File(file.OpenRead(), "application/octet-stream", file.Name);
}
