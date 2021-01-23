    public JsonResult GetLicenses()
            {
                var result = string.Empty;
                const string url = "http://data.fcc.gov/api/license-view/basicSearch/getLicenses?searchValue=Verizon+Wireless&format=jsonp&jsonCallback=?";
    
                var webRequest = WebRequest.Create(url);
    
                webRequest.Timeout = 2000;
    
                using (var response = webRequest.GetResponse() as HttpWebResponse)
                {
                    if (response != null && response.StatusCode == HttpStatusCode.OK)
                    {
                        var receiveStream = response.GetResponseStream();
                        if (receiveStream != null)
                        {
                            var stream = new StreamReader(receiveStream);
                            result = stream.ReadToEnd();
                            
                        }
                    }
                }
                return Json(result,JsonRequestBehavior.AllowGet);
