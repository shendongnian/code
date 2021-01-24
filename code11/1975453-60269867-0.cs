	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	namespace SO60269403
	{
		public abstract class ANotifyPropertyChanged : INotifyPropertyChanged
		{
			public event PropertyChangedEventHandler PropertyChanged;
			protected virtual void SetProperty<T>(ref T backingStore, T newValue, [CallerMemberName] string propertyName = "")
			{
				var areEqual = ReferenceEquals(backingStore, newValue);
				if (areEqual)
					return;
				backingStore = newValue;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
