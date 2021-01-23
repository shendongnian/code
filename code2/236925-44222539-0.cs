    using System;
    using System.Collections.Concurrent;
    using System.Net;
    using System.Text;
    using System.Threading;
    namespace Service
    {
        class HttpServer : IDisposable
        {
            private HttpListener httpListener;
            private Thread listenerLoop;
            private Thread[] requestProcessors;
            private BlockingCollection<HttpListenerContext> messages;
            public HttpServer(int threadCount)
            {
                requestProcessors = new Thread[threadCount];
                messages = new BlockingCollection<HttpListenerContext>();
                httpListener = new HttpListener();
            }
            public virtual int Port { get; set; } = 80;
            public virtual string[] Prefixes
            {
                get { return new string[] {string.Format(@"http://+:{0}/", Port )}; }
            }
            public void Start(int port)
            {
                listenerLoop = new Thread(HandleRequests);
                foreach( string prefix in Prefixes ) httpListener.Prefixes.Add( prefix );
                listenerLoop.Start();
                for (int i = 0; i < requestProcessors.Length; i++)
                {
                    requestProcessors[i] = StartProcessor(i, messages);
                }
            }
            public void Dispose() { Stop(); }
            public void Stop()
            {
                messages.CompleteAdding();
                foreach (Thread worker in requestProcessors) worker.Join();
                httpListener.Stop();
                listenerLoop.Join();
            }
            private void HandleRequests()
            {
                httpListener.Start();
                try 
                {
                    while (httpListener.IsListening)
                    {
                        Console.WriteLine("The Linstener Is Listening!");
                        HttpListenerContext context = httpListener.GetContext();
                        messages.Add(context);
                        Console.WriteLine("The Linstener has added a message!");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine (e.Message);
                }
            }
            private Thread StartProcessor(int number, BlockingCollection<HttpListenerContext> messages)
            {
                Thread thread = new Thread(() => Processor(number, messages));
                thread.Start();
                return thread;
            }
            private void Processor(int number, BlockingCollection<HttpListenerContext> messages)
            {
                Console.WriteLine ("Processor {0} started.", number);
                try
                {
                    for (;;)
                    {
                        Console.WriteLine ("Processor {0} awoken.", number);
                        HttpListenerContext context = messages.Take();
                        Console.WriteLine ("Processor {0} dequeued message.", number);
                        Response (context);
                    }
                } catch { }
                Console.WriteLine ("Processor {0} terminated.", number);
            }
            public virtual void Response(HttpListenerContext context)
            {
                SendReply(context, new StringBuilder("<html><head><title>NULL</title></head><body>This site not yet implementd.</body></html>") );
            }
            public static void SendReply(HttpListenerContext context, StringBuilder responseString )
            {
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString.ToString());
                context.Response.ContentLength64 = buffer.Length;
                System.IO.Stream output = context.Response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
        }
    }
