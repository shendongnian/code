    private readonly string _downloadUrl = "https://web.mywebsite.com/api/query?entity=sms&api_key=c652414a6&take=100";
    private dynamic _sfResult;
    
    public static string DownloadJson(string downloadURL)
    {
        using (WebClient client = new WebClient())
        {
            return client.DownloadString(downloadURL);
        }
    }    
    
    public override void PreExecute()
    {  
    	Trace.WriteLine("SSIS download!");
        var jsonFileContent = DownloadJson(_downloadUrl);
        Trace.WriteLine("SSIS download done!");
    	
    	JavaScriptSerializer js = new JavaScriptSerializer();
        js.MaxJsonLength = 500 * 1000000;
    	_sfResult = js.DeserializeObject(jsonFileContent);
    }
    
    public override void CreateNewOutputRows()
    {    
    	foreach (var therecord in _sfResult)
        {
            Trace.WriteLine("SSIS Id");        
            Output0Buffer.AddRow();        // 
            Output0Buffer.Id = (uint)therecord ["Id"];
            //.....
        }
    }
