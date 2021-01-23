    static void Main(string[] args)
        {
            //Note, I don't have a multihomed machine, so I'm not using the IP in my test implementation.  The bind delegate increments a counter and returns IPAddress.Any.
            UseIP ip = new UseIP("111.111.111.111");
            for (int i = 0; i < 100; ++i)
            {
                HttpWebRequest req = ip.CreateWebRequest(new Uri("http://www.yahoo.com"));
                using (WebResponse response = req.GetResponse())
                {
                }
            }
            Console.WriteLine(string.Format("Req: {0}", UseIP.RequestCount));
            Console.WriteLine(string.Format("Bind: {0}", UseIP.BindCount));
        }
