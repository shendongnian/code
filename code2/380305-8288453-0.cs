            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://google.com");
            req.Method = "GET";
            req.Timeout = 282;
            CookieContainer cont = new CookieContainer();
            req.CookieContainer = cont;
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
            {
                Console.Write(reader.ReadToEnd());
            }
            resp.Close();
            req.Abort();
            Console.ReadLine();
