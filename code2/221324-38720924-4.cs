        public static string CityStateCountByIp(string IP)
        {
          //var url = "http://freegeoip.net/json/" + IP;
          //var url = "http://freegeoip.net/json/" + IP;
            string url = "http://api.ipstack.com/" + IP + "?access_key=[KEY]";
            var request = System.Net.WebRequest.Create(url);
            
             using (WebResponse wrs = request.GetResponse())
             using (Stream stream = wrs.GetResponseStream())
             using (StreamReader reader = new StreamReader(stream))
             {
              string json = reader.ReadToEnd();
              var obj = JObject.Parse(json);
                string City = (string)obj["city"];
                string Country = (string)obj["region_name"];                    
                string CountryCode = (string)obj["country_code"];
            
               return (CountryCode + " - " + Country +"," + City);
               }
      return "";
    
    }
