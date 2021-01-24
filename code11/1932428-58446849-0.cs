    static void Main(string[] args)
        {
            HttpListener server = new HttpListener();  // this is the http server
            //server.Prefixes.Add("http://127.0.0.1/");  //we set a listening address here (localhost)
            server.Prefixes.Add("http://localhost:2002/");
            server.Start();   // and start the server
            Console.WriteLine("Server started...");
            while (true)
            {
                HttpListenerContext context = server.GetContext();
                HttpListenerResponse response = context.Response;
                Console.WriteLine("URL: {0}", context.Request.Url.OriginalString);
                Console.WriteLine("Raw URL: {0}", context.Request.RawUrl);
                byte[] buffer = File.ReadAllBytes("..\\Debug" + context.Request.RawUrl.Replace("%20", " "));
                response.ContentLength64 = buffer.Length;
                Stream st = response.OutputStream;
                st.Write(buffer, 0, buffer.Length);
                context.Response.Close();
            }
        }
