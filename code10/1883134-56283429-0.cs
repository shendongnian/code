            using (HttpListener listener = new HttpListener())
            {
                listener.Prefixes.Add("http://localhost:{port}/"); //Only listen to this particular address
                listener.Start();
                //blocking call. Feel free to use async version
                HttpListenerContext context = listener.GetContext(); 
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                //Here is the response url. The token should be inside url query param.
                Console.WriteLine(request.Url); 
                //redirects user back to your site and show a login success screen
                response.Redirect("{yourdomain}/loginsuccess");
                //Important! call close to send out the response
                response.Close();
                //Important! If listener is stopped before response is sent out then it will abort.
                Thread.Sleep(1000);
                listener.Stop();
            }
