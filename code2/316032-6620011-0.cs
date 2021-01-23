    System.Web.Script.Serialization.JavaScriptSerializer oSerializer = 
             new System.Web.Script.Serialization.JavaScriptSerializer();
    string barJson = oSerializer.Serialize(bar.ToArray<string>());
    
    myWebBrowser.InvokeScript("myJsFunc", new object[] { foo.Text, barJson});
