    public partial class _Default : Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/json";
            SomeObject result = ... fetch from db or something
            var serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(result);
            Response.Write(json);
        }
    }
