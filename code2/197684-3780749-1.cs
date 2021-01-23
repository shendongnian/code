    public class CsvHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=foo.csv");
            context.Response.ContentType = "text/csv";
            context.Response.Write("val1,val2,val3");
        }
        public bool IsReusable
        {
            get { return true; }
        }
    }
