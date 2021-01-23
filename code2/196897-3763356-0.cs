    public class IISHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            myent logo = new myent();
            var query = (from p in logo.tblLogoes
                        where p.Id == id && p.Id2 == id2
                        select p.Image).First();
            byte[] bytes = query.bytes;
            context.Response.OutputStream.Write( bytes, 0, bytes.Length);
        }
    }
