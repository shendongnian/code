    public class MyData
    {
        public string Key {get;set;}
        public DisplayProperties DisplayProperties {get;set;}
    }
    public class DisplayProperties
    {
       public string Description {get;set;}
       public string Name {get;set;}
       public string Icon {get;set;}
       public bool HasIcon {get;set;}
    }
    var myData = response.Content.ReadAsAsync<MyData>().Result;
    if(!string.IsNullOrWhiteSpace(myData.Key) && !string.IsNullOrWhiteSpace(myData.DisplayProperties?.Name)
    //add to list
