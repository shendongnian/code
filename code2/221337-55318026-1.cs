        private static string GetLocationIPSTACK(string ipaddress)
        {
            try
            {
                IPDataIPSTACK ipInfo = new IPDataIPSTACK();
                string strResponse = new WebClient().DownloadString("http://api.ipstack.com/" + ipaddress + "?access_key=XX384X1XX028XX1X66XXX4X04XXXX98X");
                if (strResponse == null || strResponse == "") return "";
                ipInfo = JsonConvert.DeserializeObject<IPDataIPSTACK>(strResponse);
                if (ipInfo == null || ipInfo.ip == null || ipInfo.ip == "") return "";
                else return ipInfo.city + "; " + ipInfo.region_name + "; " + ipInfo.country_name + "; " + ipInfo.zip;
            }
            catch (Exception)
            {
                return "";
            }
        }
    public class IPDataIPSTACK
    {
        public string ip { get; set; }
        public int city { get; set; }
        public string region_code { get; set; }
        public string region_name { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public string zip { get; set; }
        
    }
