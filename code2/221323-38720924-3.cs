        public static string CityStateCountByIp(string IP)
        {
          var url = "http://freegeoip.net/json/" + IP;
            var request = System.Net.WebRequest.Create(url);
            
             using (WebResponse wrs = request.GetResponse())
             using (Stream stream = wrs.GetResponseStream())
             using (StreamReader reader = new StreamReader(stream))
             {
              string json = reader.ReadToEnd();
              var obj = JObject.Parse(json);
              var City = (string)obj["city"];
                                // - For Country = (string)obj["region_name"];                    
                                //- For  CountryCode = (string)obj["country_code"];
            
               return (City);
               }
      return "";
    
    }
