[Route("api/flight/{flight}/{*file}")]
[HttpGet]
public async Task<IActionResult> GetImageThumbnail([FromRoute]int flight, 
	[FromRoute] string file)
{
	
	// Check permission
	List<Flight> data = _context
	.Flight(id: flight)
	.ToList();
	if (data.Count() == 0)
	{
	return NotFound("No permission.");
	}
	string filename = Path.Combine(data[0].BaseFolder, file);
	var provider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider();
            
	string minetype = "";
	provider.TryGetContentType(filename, out minetype);
	return PhysicalFile(filename, minetype);
}
