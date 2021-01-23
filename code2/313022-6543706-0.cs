    public class getfile : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var targetId = context.Request.QueryString["target"];
            if (string.IsNullOrWhiteSpace(targetId))
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Fail: Target was expected in querystring.");
                return;
            }
            try
            {
                var url = new String(Encoding.UTF8.GetChars(Convert.FromBase64String(targetId)));
                var filename = url.Substring(url.LastIndexOf('\\') + 1);
                filename = "export-" + DateTime.Now.ToString("yyyy-MM-dd-HHmm") + filename.Substring(filename.Length - 4);
                context.Response.ContentType = "application/octet-stream";
                context.Response.AppendHeader("Content-Disposition", String.Format("attachment;filename={0}", filename));
                var data = File.ReadAllBytes(url);
                File.Delete(url);
                context.Response.BinaryWrite(data);
            }
            catch (Exception ex)
            {
                context.Response.Clear();
                context.Response.Write("Error occurred: " + ex.Message);
                context.Response.ContentType = "text/plain";
                context.Response.End();
            }
        }
        public bool IsReusable { get { return false; } }
    }
