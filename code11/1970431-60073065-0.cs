[HttpGet]
[Route("YourController/{fileName}")]
public HttpResponseMessage Download(string fileName) //Parameter is yours
{
	string filePath = (@"C:\Uploads\" + input.ID + @"\" + fileName);
    if (!File.Exists(filePath))
    {
        response.StatusCode = HttpStatusCode.NotFound;
        response.ReasonPhrase = string.Format("File not found: {0} .", fileNm);
        throw new HttpResponseException(response);
    }
    byte[] bytes = File.ReadAllBytes(filePath);
	using (var ms = new MemoryStream(bytes))
	{
		var result = new HttpResponseMessage(HttpStatusCode.OK)
		{
			Content = new ByteArrayContent(ms.ToArray())
		};
		result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
		{
			FileName = fileName //String value of the file name.
		};
		string mimeType = MimeMapping.GetMimeMapping(fileName); //I've found that this does not always work. Go here for a better answer: https://stackoverflow.com/questions/1029740/get-mime-type-from-filename-extension
		result.Content.Headers.ContentType = new MediaTypeHeaderValue(mimeType); //The mime type retrieved from the 
		return result;
	}
}
In javascript you can use: `window.open('yourApiURL/YourController/FileName');`
