    int n = 16;
    int reqs = 10;
    
    var totalTimes = new long[n];
    
    Parallel.For(0, n, i =>
        {
            for (int req = 0; req < reqs; req++)
            {
                Stopwatch w = new Stopwatch();
                try
                {
                    w.Start();
    
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:42838/Default.aspx");
                    webRequest.AllowAutoRedirect = false;
                    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
    
                    w.Stop();
                    totalTimes[i] += w.ElapsedMilliseconds;
    
    
                    //Returns "MovedPermanently", not 301 which is what I want.            
                    int i_goodResponse = (int)response.StatusCode;
                    string s_goodResponse = response.StatusCode.ToString();
                    Console.WriteLine("Normal Response: " + i_goodResponse + " " + s_goodResponse);
                }
                catch (WebException we)
                {
                    w.Stop();
                    totalTimes[i] += w.ElapsedMilliseconds;
    
                    int i_badResponse = (int)((HttpWebResponse)we.Response).StatusCode;
                    string s_badResponse = ((HttpWebResponse)we.Response).StatusCode.ToString();
                    Console.WriteLine("Error Response: " + i_badResponse + " " + s_badResponse);
                }
            }
        });
    
    var grandTotalTime = totalTimes.Sum();
    var reqsPerSec = (double)(n * reqs * 1000) / (double)grandTotalTime;
    
    Console.WriteLine("Requests per second: {0}", reqsPerSec);
