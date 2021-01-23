        public static {Object_Name} GetUser(this Controller controller)
        {
            var httpRequest = controller.Request;
            if (httpRequest.Cookies[{cookie_name}] == null)
            {
                return null;
            }
            else
            {
                var json = httpRequest.Cookies[{cookie_name}].Value;
                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                var result = serializer.Deserialize<{object_name}>(json);
                return result;
            }
        }
