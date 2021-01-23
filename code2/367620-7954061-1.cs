    [WebMethod]
    public void HelloWorld()
    {
    	Context.Response.ContentType = "text/plain";
    	Context.Response.Write("alert('Hello world');");
    	Context.Response.End();
    }
