    public IHttpActionResult Get() {
        var message = "I am send by HTTP response";
        var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
        {
          Content = new StringContent(message, System.Text.Encoding.UTF8, "text/plain")
        };
