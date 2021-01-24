    public delegate void EventDelegate(object data);
    
    public static Dictionary<EventTypes, EventDelegate> Events =
    	new Dictionary<EventTypes, EventDelegate>
    	{
    		{ EventTypes.Event1, (EventDelegate)((_) => { }) },
    		{ EventTypes.Event2, (EventDelegate)((_) => { }) },
    		{ EventTypes.Event3, (EventDelegate)((_) => { }) },
    	};
    
    public enum EventTypes
    {
    	Event1,
    	Event2,
    	Event3,
    }
