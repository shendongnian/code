	public static void OnPropertyChanged<P>(INotifyPropertyChangedAmendment instance, string property, P oldValue, P value, P newValue)
	{
		// Only raise property changed if the value of the property actually changed
		if ((oldValue == null ^ newValue == null) || (oldValue != null && !oldValue.Equals(newValue)))
			instance.OnPropertyChanged(new PropertyChangedEventArgs(property));
	}
