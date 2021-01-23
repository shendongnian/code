    [AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
    public class EventIdInfoAttribute : Attribute
    {
        public EventIdInfoAttribute(uint value)
            : this((ushort)((value >> 20) & 0xFFF),
                   (byte)((value >> 16) & 0xF),
                   (ushort)(value & 0xFFFF))
        {
        }
        public EventIdInfoAttribute(ushort subsystemId, byte notificationType, ushort notificationId)
        {
            this.SubsystemId = subsystemId;
            this.NotificationType = notificationType;
            this.NotificationId = notificationId;
        }
        public ushort SubsystemId { get; private set; }
        public byte NotificationType { get; private set; }
        public ushort NotificationId { get; private set; }
    }
    public enum EventId : uint
    {
        [EventIdInfo(0xDCCA0000)] SAMPLE_EVENT_1,
        [EventIdInfo(0xDCCB0001)] SAMPLE_EVENT_2,
        [EventIdInfo(0xDCCA0002)] SAMPLE_EVENT_3,
        [EventIdInfo(0xDCC00003)] SAMPLE_EVENT_4,
        [EventIdInfo(0xDCCA0004)] SAMPLE_EVENT_5,
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
