    public class PublicController : ApiController
	{
		[Route("GetContent")]
		public async Task<HttpResponseMessage> Get()
		{
			using (var client = new HttpClient())
			{
				try
				{
					client.BaseAddress = new Uri("http://localhost:9000/");
					var responseFromServer = await client.GetAsync("api/Test/GetContent");
					Stream streamToReadFrom = await responseFromServer.Content.ReadAsStreamAsync();
					HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
					response.Content = new StreamContent(streamToReadFrom);
					response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
					response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
					response.Content.Headers.ContentDisposition.FileName = "sd.json";
					return response;
				}
				catch (Exception ex)
				{
					return new HttpResponseMessage(HttpStatusCode.NotFound);
				}
			}
		}
	}
