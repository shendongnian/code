    [AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
    public class EventIdInfoAttribute : Attribute
    {
        public EventIdInfoAttribute(ushort value)
            : this((ushort)((value >> 4) & 0xFFF),
                   (byte)(value & 0xF))
        {
        }
        public EventIdInfoAttribute(ushort subsystemId, byte notificationType)
        {
            this.SubsystemId = subsystemId;
            this.NotificationType = notificationType;
        }
        public ushort SubsystemId { get; private set; }
        public byte NotificationType { get; private set; }
    }
    public enum EventId
    {
        [EventIdInfo(0xDCCA)] SAMPLE_EVENT_1,
        [EventIdInfo(0xDCCB)] SAMPLE_EVENT_2,
        [EventIdInfo(0xDCCA)] SAMPLE_EVENT_3,
        [EventIdInfo(0xDCC0)] SAMPLE_EVENT_4,
        [EventIdInfo(0xDCCA)] SAMPLE_EVENT_5,
    }
    public static class EventIdExtensions
    {
        public static EventIdInfoAttribute GetEventIdInfo(this EventId eventId)
        {
            return typeof(EventId).GetField(eventId.ToString())
                .GetCustomAttributes(false)
                .OfType<EventIdInfoAttribute>()
                .Single();
        }
    }
