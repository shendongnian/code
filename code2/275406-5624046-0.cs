    public static class EventHelper
    {
        public static void SubscribeOneShot(
            Action<EventHandler> subscribe,
            Action<EventHandler> unsubscribe,
            EventHandler handler)
        {
            EventHandler actualHandler = null;
            actualHandler = (sender, e) =>
            {
                unsubscribe(actualHandler);
                handler(sender, e);
            };
            subscribe(actualHandler);
        }
    }
    ...
    Foo f = new Foo();
    EventHelper.SubscribeOneShot(
        handler => f.Bar += handler,
        handler => f.Bar -= handler,
        (sender, e) => { /* whatever */ });
