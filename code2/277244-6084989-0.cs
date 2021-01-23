    // Complete async GetContext and reference required objects
    HttpListenerContext Context = Listener.EndGetContext(Result);
    HttpListenerRequest Request = Context.Request;
    HttpListenerResponse Response = Context.Response;
    // Process the incoming request here
    // Complete the request and release it's resources by call the Close method
    Response.Close();
