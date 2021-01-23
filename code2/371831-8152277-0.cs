    public FileContentResult GetGraph(int id)
	{
		var image = Resolve<CountryModel>().Load(id).Graph; //gets our Bitmap object
		image.Save(HttpContext.Response.OutputStream, ImageFormat.Jpeg);
		var converter = new ImageConverter();
		return new FileContentResult((byte[])converter.ConvertTo(image, typeof(byte[])), "image/jpeg");
	}
