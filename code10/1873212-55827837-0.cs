	public interface IImageBrowserControllerAsync
	{
		Task<IActionResult> Create(string name, FileBrowserEntry entry);
		Task<IActionResult> Destroy(string name, FileBrowserEntry entry);
		Task<IActionResult> Image(string path);
		Task<JsonResult> Read(string path);
		Task<IActionResult> Thumbnail(string path);
		Task<IActionResult> Upload(string name, IFormFile file);
	}
