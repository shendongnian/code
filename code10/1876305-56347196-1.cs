    public class NotificationListViewModel
    {
        public NotificationListViewModel(INotificationProvider provider)
        {
			provider.Notifications.Subscribe(change => 
			{
			  if(change.Type == ChangeType.Add)
			  {
				Items.Add(change.Value);
			  }
			  if(change.Type == ChangeType.Update)
			  {
				Items.First(x => x.Id = change.Value.Id).Update(change.Value);
			  }
			  if(change.Type == ChangeType.Remove)
			  {
				Items.Remove(change.Value);
			  }
			});
		}
    }
