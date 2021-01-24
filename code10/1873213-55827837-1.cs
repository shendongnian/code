	public class ImageBrowserController : ControllerBase, IImageBrowserControllerAsync
	{
		private IImageRepository _repo;
		private const int ThumbnailHeight = 80,
			ThumbnailWidth = 80;
		public ImageBrowserController(IImageRepository repo)
		{
			_repo = repo;
		}
		[Route("Image")]
		public async Task<IActionResult> Image(string path)
		{
			var image = await _repo.GetByName(path);
			if (image != null)
			{
				return File(image.Data, image.ContentType);
			}
			return NotFound("Errormessage");
		}
		//read all images, when the widget loads
		[Route("Read")]
		public async Task<JsonResult> Read(string path)
		{
			var images = await _repo.Get(); // do not return the image data. it is not 
            //needed and will clog up your resources
			var fbe = images.Select(x => new FileBrowserEntry
			{
				Name = x.Name,
				EntryType = FileBrowserEntryType.File
			});
			return new JsonResult(fbe);
		}
        //Create thumbnail using SixLabors.Imagesharp library
		[Route("Thumbnail")]
		public async Task<IActionResult> Thumbnail(string path)
		{
			var image = await _repo.GetByName(path);
			if (image != null)
			{
				var i = SixLabors.ImageSharp.Image
					.Load(image.Data);
				i.Mutate(ctx => ctx.Resize(ThumbnailWidth, ThumbnailHeight));
				using (var ms = new MemoryStream())
				{
					i.SaveAsJpeg(ms);
					return File(ms.ToArray(), image.ContentType);
				}
			}
			return NotFound();
		}
        
		[Route("Upload")]
		public async Task<IActionResult> Upload(string name, IFormFile file)
		{
			if (file == null || file.Length == 0) return BadRequest();
			using (var ms = new MemoryStream())
			{
				file.CopyTo(ms);
				var img = new Entities.Image
				{
					Name = file.FileName,
					ContentType = file.ContentType,
					Data = ms.ToArray()
				};
				await _repo.CreateImage(img);
				return Ok();
			}
		}
	}
