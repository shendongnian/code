	public override void Amend<TProperty>(Property<TProperty> property)
	{
		// Raise property change notifications
		if (property.PropertyInfo.CanRead && property.PropertyInfo.CanWrite)
			property.AfterSet = NotificationAmender<T>.OnPropertyChanged<TProperty>;
	}
