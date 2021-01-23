public List&lt;string> DownloadUrlsInParallel(Uri[] urls)
        {            
            var tasks = urls
                .Select(url => Task.Factory.StartNew<string>(
                    state =>
                    {
                        using (var client = new System.Net.WebClient())
                        {
                            var u = (Uri)state;
                            Console.WriteLine("starting to download {0}", u);
                            string result = client.DownloadString(u);
                            Console.WriteLine("finished downloading {0}", u);
                            return result;
                        }
                    }, url)
                )
                .ToArray();
            Task.WaitAll(tasks);
            List&lt;string> ret = new List<string>();
            foreach(var t in tasks)
            {
                ret.Add(t.Result);
            }
            return ret;            
        }</code></pre>
