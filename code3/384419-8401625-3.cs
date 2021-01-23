    public class EventInfo
    {
        //c# auto-implemented properties
        public string Bla {get; set;} 
        public int Bla2 {get; set;}
    }
    //set on one page
    var eventInfo = new EventInfo();
    eventInfo.Bla = "bla";
    eventInfo.Bla1 = 2;
    Sesssion["eventinfo"] = eventInfoObject;
  
    //get on another
    var eventInfo = (EventInfo)Session["eventinfo"]; //add null checks etc
    string bla = eventInfo.Bla;
    int Bla2 = eventInfo.Bla2;
    
    //************************************************//
   
    //set multiple events in Session  
    List<EventInfo> events = new List<EventInfo>();   
    events.Add(new EventInfo{ Bla= "bla", Bla1 = 2});
    events.Add(new EventInfo{ Bla= "bla2", Bla1 = 3});
    Sesssion["eventCollection"] = events ;
    //get 
    List<EventInfo> events = (List<EventInfo>)Session["eventCollection"]; //add null checks etc
    foreach(EventInfo event in Events)
    {
        string bla = event.Bla;
        int Bla2 = event.Bla2;
    }
