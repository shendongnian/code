[HttpGet]
public IActionResult GetImage()
{           
	// Get the image blob
	CloudBlockBlob cloudBlockBlob = ********;
	using(MemoryStream ms = new MemoryStream())
	{
		cloudBlockBlob.DownloadToStream(ms);
		return File(ms.ToArray(), "image/jpeg");
	}
}
