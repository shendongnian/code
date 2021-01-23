    public class EventId
    {
        public static readonly SAMPLE_EVENT_1 = new EventId(0xDCC, 0xA);
        public static readonly SAMPLE_EVENT_2 = new EventId(0xDCC, 0xA);
        public static readonly SAMPLE_EVENT_3 = new EventId(0xDCC, 0xA);
        public static readonly SAMPLE_EVENT_4 = new EventId(0xDCC, 0xA);
        public readonly ushort SubSystemId;
        public readonly byte NotificationType;
        public readonly ushort NotificationId;
        private static ushort notificationCounter = 0;
        private EventId(ushort subSystemId, byte notificationType)
        {
            this.SubSystemId = subSystemId;
            this.NotificationType= notificationType;
            this.NotificationId = notificationCounter++;
        }
    }
