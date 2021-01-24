C#
[HttpGet]
public async Task<IActionResult> GetFile()
{
    var temporaryImage = System.IO.File.OpenRead("Path to the file");
    //Replace "image/jpeg" with the mimetype of your image.
    return File(temporaryImage, "image/jpeg");
}
