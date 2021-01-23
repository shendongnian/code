    [AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
    public class SubsystemIdAttribute : Attribute
    {
        public SubsystemIdAttribute(ushort value)
        {
            this.Value = (ushort)(value & 0xFFF);
        }
        public ushort Value { get; private set; }
    }
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class NotificationTypeAttribute : Attribute
    {
        public NotificationTypeAttribute(byte value)
        {
            this.Value = (byte)(value & 0xF);
        }
        public byte Value { get; private set; }
    }
    public enum EventId
    {
        [SubsystemId(0xDCC)] [NotificationType(0xA)] SAMPLE_EVENT_1,
        [SubsystemId(0xDCC)] [NotificationType(0xB)] SAMPLE_EVENT_2,
        [SubsystemId(0xDCC)] [NotificationType(0xA)] SAMPLE_EVENT_3,
        [SubsystemId(0xDCC)] [NotificationType(0x0)] SAMPLE_EVENT_4,
        [SubsystemId(0xDCC)] [NotificationType(0xA)] SAMPLE_EVENT_5,
    }
    public static class EventIdExtensions
    {
        public static ushort GetSubsystemId(this EventId eventId)
        {
            return GetAttributeValue(eventId, (SubsystemIdAttribute a) => a.Value);
        }
        public static byte GetNotificationType(this EventId eventId)
        {
            return GetAttributeValue(eventId, (NotificationTypeAttribute a) => a.Value);
        }
        private static TValue GetAttributeValue<TAttribute, TValue>(EventId eventId, Func<TAttribute, TValue> selector)
            where TAttribute : Attribute
        {
            return typeof(EventId).GetField(eventId.ToString())
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .Select(selector)
                .Single();
        }
    }
