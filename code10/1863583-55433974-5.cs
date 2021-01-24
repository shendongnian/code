    public delegate void EventDelegate(object data);
    public static readonly EventDelegate EventDelegateEmptyBody = (_) => { };
    public static Dictionary<EventTypes, EventDelegate> Events = new Dictionary<EventTypes, EventDelegate>
    {
        {EventTypes.Event1, EventDelegateEmptyBody},
        {EventTypes.Event2, EventDelegateEmptyBody},
        {EventTypes.Event3, EventDelegateEmptyBody},
    };
