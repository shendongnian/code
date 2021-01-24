		public class FileAPIController : ApiController
		{
			[HttpGet]
			[Route("api/FileAPI/GetFile")]
			public HttpResponseMessage GetFile(string fileName)
			{
				//Create HTTP Response.
				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
		 
				//Set the File Path.
				string filePath = HttpContext.Current.Server.MapPath("~/Files/") + fileName;
		 
				//Check whether File exists.
				if (!File.Exists(filePath))
				{
					//Throw 404 (Not Found) exception if File not found.
					response.StatusCode = HttpStatusCode.NotFound;
					response.ReasonPhrase = string.Format("File not found: {0} .", fileName);
					throw new HttpResponseException(response);
				}
		 
				//Read the File into a Byte Array.
				byte[] bytes = File.ReadAllBytes(filePath);
		 
				//Set the Response Content.
				response.Content = new ByteArrayContent(bytes);
		 
				//Set the Response Content Length.
				response.Content.Headers.ContentLength = bytes.LongLength;
		 
				//Set the Content Disposition Header Value and FileName.
				response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
				response.Content.Headers.ContentDisposition.FileName = fileName;
		 
				//Set the File Content Type.
				response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(fileName));
				return response;
			}
		}
