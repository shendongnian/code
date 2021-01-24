    public class Activity
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
    var activity= response.Content.ReadAsAsync<Activity>().Result;
    if(!string.IsNullOrWhiteSpace(activity.Key) && !string.IsNullOrWhiteSpace(activity.DisplayProperties?.Name)
    //add to list
