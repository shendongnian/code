    public static IPAddress GetExternalIP()
    {
            string url = "http://www.whatismyip.com/automation/n09230945.asp";
            WebClient webClient = new WebClient();
            string response = utf8.GetString(webClient .DownloadData(whatIsMyIp));
            IPAddress ip = IPAddress.Parse(response);
            return ip;   
    }
