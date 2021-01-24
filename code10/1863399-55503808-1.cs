csharp
    // This example requires the System and System.Net namespaces.
    public static void SimpleListenerExample(string[] prefixes)
    {
        // 1
        HttpListener listener = new HttpListener();
        // 2
        listener.Prefixes.Add("http:/localhost:8080//api/v1/myapi/");
        
        // 3
        listener.Start();
        Console.WriteLine("Listening...");
        //4
        HttpListenerContext context = listener.GetContext();
        HttpListenerRequest request = context.Request;
        //5
        HttpListenerResponse response = context.Response;
        //Building a response
        string responseString = "<HTML><BODY>My response</BODY></HTML>";
        //Take care of encoding
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
        //6
        response.ContentLength64 = buffer.Length;
        //Get the stream to wite the response body
        System.IO.Stream output = response.OutputStream;
        output.Write(buffer,0,buffer.Length);
        // You must close the output stream.
        output.Close();
        listener.Stop();
    }
if you don't want to use `HttpListener` you can use these basic steps, using `TCPListener` and `TCPClient` but you must have knowledge about HTTP Protocol:
1. Read the Header, line by line.
2. Valid if there is Body, using the the `content-length` header.
3. Read the body, according information of the size of `content-length`.
In my case, i prefer use `HttpListener`, which allows handle several aspect of HTTP, like certified.
