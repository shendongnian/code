     public interface IEvent
        {
        int event Id {get;set}
        string EventName{get;set}
        } 
    
        public interface IEventDES
        {
        string event Description{get;set}
        }
    
        public class Event:IEvent, IEventDES
         {
            public Event(int eventID,string eventName, string Description)
            {
               this.EventID=eventID; 
               this.EventName=eventName;
    this.Description= Description;
            }
         }
