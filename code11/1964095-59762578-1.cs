    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    {
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            var res = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var dataObj = JsonConvert.DeserializeObject<dynamic>(res.ToString());
        
            try
            {
                var resultObj = dataObj["result"].Value;
                string callNumber = resultObj["number"].Value.ToString();
            }
            catch
            {
                // Handle your exceptions here
            }
        
            return (res.ToString());
        }
    };
