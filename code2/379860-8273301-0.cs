	public class NotifyPerson : IPerson, INotifyPropertyChanged
	{
		readonly IPerson _inner;
		public NotifyPerson(IPerson inner) // repository puts the "true" domain entity here
		{
			_inner = inner;
		}
		public DateTime BirthDate
		{
			set 
			{
				if(value == _inner.BirthDate)
					return;
				var previousBirthPlace = BirthPlace;
				_inner.BirthDate = value;
				Notify("BirthDate");
				if(BirthPlace != previousBirthPlace) 
					Notify("BirthPlace");
			}
		}
		void Notify(string property)
		{
			var handler = PropertyChanged;
			if(handler != null) handler(this, new PropertyChangedEventArgs(property));
		}
	}
