    public static class StubIRelayServiceExtensions
    {
        public static bool EventHasSubscriber(this IRelayService relayService, string eventName)
        {
            var eventField = relayService.GetType().GetField(eventName + "Event",
                BindingFlags.Public | BindingFlags.Instance);
            object object_value = eventField.GetValue(relayService);
            return object_value != null;
        }
    }
