        public static string GetLocationIPAPI(string ipaddress)
        {
            try
            {
                IPDataIPAPI ipInfo = new IPDataIPAPI();
                string strResponse = new WebClient().DownloadString("http://ip-api.com/json/" + ipaddress);
                if (strResponse == null || strResponse == "") return "";
                ipInfo = JsonConvert.DeserializeObject<IPDataIPAPI>(strResponse);
                if (ipInfo == null || ipInfo.status.ToLower().Trim() == "fail") return "";
                else return ipInfo.city + "; " + ipInfo.regionName + "; " + ipInfo.country + "; " + ipInfo.countryCode;
            }
            catch (Exception)
            {
                return "";
            }
        }
    public class IPDataIPINFO
    {
        public string ip { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string loc { get; set; }
        public string postal { get; set; }
        public int org { get; set; }
    }
==========================
        public static string GetLocationIPINFO(string ipaddress)
        {            
            try
            {
                IPDataIPINFO ipInfo = new IPDataIPINFO();
                string strResponse = new WebClient().DownloadString("http://ipinfo.io/" + ipaddress);
                if (strResponse == null || strResponse == "") return "";
                ipInfo = JsonConvert.DeserializeObject<IPDataIPINFO>(strResponse);
                if (ipInfo == null || ipInfo.ip == null || ipInfo.ip == "") return "";
                else return ipInfo.city + "; " + ipInfo.region + "; " + ipInfo.country + "; " + ipInfo.postal;
            }
            catch (Exception)
            {
                return "";
            }
        }
    public class IPDataIPAPI
    {
        public string status { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string region { get; set; }
        public string regionName { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string timezone { get; set; }
        public string isp { get; set; }
        public string org { get; set; }
        public string @as { get; set; }
        public string query { get; set; }
    }
    
