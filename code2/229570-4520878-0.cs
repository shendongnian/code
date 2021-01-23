		private static void SetterInterceptor<T, TProperty>(ProxiedProperty<T, TProperty> property, T target, TProperty value) where T:class,IAutoNotifyPropertyChanged
		{
			TProperty oldValue;
			if (!EqualityComparer<TProperty>.Default.Equals(oldValue = property.GetMethod.CallBaseDelegate(target), value))
			{
				property.SetMethod.CallBaseDelegate(target, value);
				target.OnPropertyChanged(new PropertyChangedEventArgs(property.Property.Name));
			}
		}
