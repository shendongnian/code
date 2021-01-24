    public class TestController : ApiController
	{
		[Route("GetContent")]
		public HttpResponseMessage Get()
		{
			string fileName = "a.json";
			string fullPath = AppDomain.CurrentDomain.BaseDirectory + fileName;
			if (File.Exists(fullPath))
			{
				HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
				var fileStream = new FileStream(fullPath, FileMode.Open);
				response.Content = new StreamContent(fileStream);
				response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
				response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
				response.Content.Headers.ContentDisposition.FileName = fileName;
				return response;
			}
			return null;
		}
	}
