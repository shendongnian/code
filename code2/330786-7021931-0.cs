	public class ImageServer : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			var path = context.Request["path"];
			context.Response.ContentType = "image/jpeg";
			context.Response.TransmitFile(path);
		}
		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
