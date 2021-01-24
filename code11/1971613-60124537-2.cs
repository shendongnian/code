        public static IObservable<T> NotifyAs<T>(this IObservable<T> source, Func<T, NotificationKind> choice, Exception exception = default)
        {
            return source.Select(value =>
            {
                switch (choice(value))
                {
                    case NotificationKind.OnError:
                        return Notification.CreateOnError<T>(exception ?? new Exception());
                    case NotificationKind.OnCompleted:
                        return Notification.CreateOnCompleted<T>();
                    default:
                        return Notification.CreateOnNext(value);
                }
            })
            .Dematerialize();
        }
