    public ActionResult Licenses()
    {
		var result = string.Empty;
		var url = "http://data.fcc.gov/api/license-view/basicSearch/getLicenses?searchValue=Verizon+Wireless&format=jsonp&jsonCallback=?";
		var webRequest = WebRequest.Create(url);
		webRequest.Timeout = 2000;
		using (var response = webRequest.GetResponse() as HttpWebResponse)
		{
			if (response.StatusCode == HttpStatusCode.OK)
			{
				var receiveStream = response.GetResponseStream();
				if (receiveStream != null)
				{
					var stream = new StreamReader(receiveStream);
					result = stream.ReadToEnd();
				}
			}
		}
		if(result != null)
		{
			 JavaScriptSerializer serializer = new JavaScriptSerializer();
			 var licenses = serializer.Deserialize<List<License>>(result);
		}
		return View(licenses);
    }
