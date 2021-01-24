public class YourDataModel 
{
   public IFormFile File { get; set; }
   // whatever other properties you need
}
Try something like this in your API Controller: 
[HttpPost]
async public Task<ActionResult> Save([FromForm]YourDataModel file)
{
   // your logic
}
