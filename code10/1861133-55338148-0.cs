    // parameter to get list of currentSpeed
    // Keep track of what we got back
    string recentData = "";
    List<string> LrecentData = new List<string>();
  
    string GenerateUrls(string typeFile,float lat,float lon)
    {
        const string API_KEY= "?key=hcbqhqcbcqkbclcblcbcbqjq";
        
        const string DEFAULT_URL = "https://api.tomtom.com/traffic/services/4/flowSegmentData/relative-delay/10/";
        typeFile = typeFile + "/";// xml or json
        string geoloc= "&point=" + lat.ToString() + "," + lon.ToString();
        string targetUrl = DEFAULT_URL + typeFile + API_KEY + geoloc;
        
        return targetUrl.ToString();
    }
    // Web requests are typically done asynchronously, so Unity's web request system
    // returns a yield instruction while it waits for the response.
    //
    private IEnumerator RequestRoutine(Action<string> callback = null){
        //List<string> Lurl = new List<string>();
        string url0, url1, url2, url3, url4;
        
        url0 = GenerateUrls("json", 50.843829f, 4.369384f);
        url1 = GenerateUrls("json", 50.844773f, 4.356664f);
        url2 = GenerateUrls("json", 50.846885f, 4.362358f);
        url3 = GenerateUrls("json", 50.852922f, 4.360137f);
        url4 = GenerateUrls("json", 50.852440f, 4.367985f);
        var Lurl = new List<string>() { url0, url1, url2, url3, url4 };
        var Ldata = new List<string>();
        
        foreach (string x in Lurl)
        {
            var request = UnityWebRequest.Get(x);
            yield return request.SendWebRequest();
            var data = request.downloadHandler.text;
            Ldata.Add(data);
            if (callback != null)
                Debug.Log(callback);
            callback(data);}}
    
    // Callback to act on our response data
    private void ResponseCallback(string data)
    {  
        Debug.Log(data);
        recentData = data;
        JObject o = JObject.Parse(recentData.ToString());
        JToken token = o.SelectToken("flowSegmentData.currentSpeed");
        recentData = token.ToString();
        LrecentData.Add(recentData);
    }
    // Old fashioned GUI system to show the example
    void OnGUI()
    {
       
        GUI.TextArea(new Rect(0, 0, 500, 50), LrecentData[0].ToString());
        GUI.TextArea(new Rect(0, 60, 500, 50), LrecentData[1].ToString());
        GUI.TextArea(new Rect(0, 120, 500, 50), LrecentData[2].ToString());
        GUI.TextArea(new Rect(0, 180, 500, 50), LrecentData[3].ToString());
        GUI.TextArea(new Rect(0, 240, 500, 50), LrecentData[4].ToString()); }}
