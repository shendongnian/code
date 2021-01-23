    public class EventInfo
    {
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
