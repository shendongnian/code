      public interface IWatchService<out TDataEntity> :
        INotifyCollectionChanged,
        INotifyPropertyChanged,
        IEnumerable<TDataEntity>
        where TDataEntity : IEntity
      {
        INotificationFactory NotificationFactory { get; }
      }
