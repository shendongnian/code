    public class EventSubscriber
    {
        private readonly List<Tuple<Control, RoutedEvent, Delegate>> 
            _subscriptions = 
                new List<Tuple<Control, RoutedEvent, Delegate>>();
    
        public void AddSubscription(Control control, RoutedEvent toSubscribe, 
                                    Delegate subscriber)
        {
            control.AddHandler(toSubscribe, subscriber);
            _subscriptions.Add(Tuple.Create(control, toSubscribe, subscriber));
        }
    
        public void UnsubscribeAll()
        {
            foreach (var subscription in _subscriptions)
            {
                subscription.Item1.RemoveHandler(subscription.Item2,
                                                 subscription.Item3);
            }
            _subscriptions.Clear();
        }
    }
