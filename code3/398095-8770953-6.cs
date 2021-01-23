    public class Foo : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var serializer = new JavaScriptSerializer();
            using (var reader = new StreamReader(context.Request.InputStream))
            {
                Person person = (Person)serializer.Deserialize<Person>(reader.ReadToEnd());
                // do some processing with the person
            }
            context.Response.ContentType = "application/json";
            var result = serializer.Serialize(new { data = "Hello World" });
            context.Response.Write(result);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
