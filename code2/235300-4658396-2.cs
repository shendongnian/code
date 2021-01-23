    public class Response
    {
        public bool flag { get; set; }
        public string message { get; set; }
        public Permisions result { get; set; }
    }
    public class Permisions
    {
        public bool ServicePermission { get; set; }
        public bool UserGroupPermission { get; set; }
    }
            var responseFromServer =
                // lines split for readability
      "{\"flag\":true,\"message\":\"\",\"result\":{\"ServicePermission\":true,"
      + "\"UserGroupPermission\":true}}";
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var responseValue = serializer.Deserialize<Response>(responseFromServer);
        //access     
        responseValue.result.ServicePermission
