    using System.Net;
    using System.IO;
    using Newtonsoft.Json.Linq;
    public ActionResult geoPlugin()
        {
            var url = "http://freegeoip.net/json/";
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
                Session["CurrentRegionName"]= (string)obj["country_name"];
                Session["CurrentRegion"] = (string)obj["country_code"];
            }
            return RedirectToAction("Index");
        }
