    public static class ObservableExtensions
    {
        public static IObservable<ItemPropertyChangingEvent<TItem, TProperty>> ObserveSpecificPropertyChanging<TItem, TProperty>(
            this TItem target, Expression<Func<TItem, TProperty>> propertyName) where TItem : INotifyPropertyChanging
        {
            var property = propertyName.GetPropertyName();
            return ObserveSpecificPropertyChanging(target, property)
                   .Select(i => new ItemPropertyChangingEvent<TItem, TProperty>()
                   {
                       OriginalEventArgs = (PropertyChangingCancelEventArgs<TProperty>)i.OriginalEventArgs,
                       Property = i.Property,
                       Sender = i.Sender
                   });
        }
        public static IObservable<ItemPropertyChangingEvent<TItem>> ObserveSpecificPropertyChanging<TItem>(
            this TItem target, string propertyName = null) where TItem : INotifyPropertyChanging
        {
            return Observable.Create<ItemPropertyChangingEvent<TItem>>(obs =>
            {
                Dictionary<string, PropertyInfo> properties = new Dictionary<string, PropertyInfo>();
                PropertyChangingEventHandler handler = null;
                handler = (s, a) =>
                {
                    if (propertyName == null || propertyName == a.PropertyName)
                    {
                        PropertyInfo prop;
                        if (!properties.TryGetValue(a.PropertyName, out prop))
                        {
                            prop = target.GetType().GetProperty(a.PropertyName);
                            properties.Add(a.PropertyName, prop);
                        }
                        var change = new ItemPropertyChangingEvent<TItem>()
                        {
                            Sender = target,
                            Property = prop,
                            OriginalEventArgs = a,
                        };
                        
                        obs.OnNext(change);
                    }
                };
                target.PropertyChanging += handler;
                return () =>
                {
                    target.PropertyChanging -= handler;
                };
            });
        }
        public class ItemPropertyChangingEvent<TSender>
        {
            public TSender Sender { get; set; }
            public PropertyInfo Property { get; set; }
            public PropertyChangingEventArgs OriginalEventArgs { get; set; }
            public override string ToString()
            {
                return string.Format("Sender: {0}, Property: {1}", Sender, Property);
            }
        }
        public class ItemPropertyChangingEvent<TSender, TProperty>
        {
            public TSender Sender { get; set; }
            public PropertyInfo Property { get; set; }
            public PropertyChangingCancelEventArgs<TProperty> OriginalEventArgs { get; set; }
        }
    }
