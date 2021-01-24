csharp
[ApiController] 
[Route("[controller]")]
public class ContentController : ControllerBase
{
   [HttpGet("project/{id}/{fileName}")] 
   public async Task<IActionResult> GetProjectThumbnail(int id, string fileName)
   {
       try
       {
           return File(await _projects.GetThumbnailAsync(id, fileName), "image/jpeg");
       }
       catch (Exception ex)
       {
           return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorResponse(ex));
       }
   }
   //...
}
After that, I can access a thumbnail via url: `https://efolio.com/content/project/1003/1.jpg`
