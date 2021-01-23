	public class Foo : INotifyPropertyChanged
	{
		void OnPropertyChanged(string propertyName) { /* ... */ }
		public object FooProp 
		{ 
			get { return _obj; }
			set 
			{
				_obj = value;
				OnPropertyChanged("FooProp");
			}
		}
	}
	public class ViewModel : INotifyPropertyChanged
	{
		void OnPropertyChanged(string propertyName) { /* ... */ }
		
		private List<Foo> _myList;
		public List<Foo> MyList 
		{ 
			get { return _myList; }
			set 
			{
				_myList = value;
				foreach(var item in _myList) 
				{
					HandleItem(item);
				}
			}
		}
		
		void AddItem(Foo item) 
		{
			MyList.Add(item);
			HandleItem(item);
		}
		void HandleItem(Foo item) 
		{
			item.PropertyChanged += (s, e) =>
			{
				if(e.PropertyName == "FooProp")
			};
		}
		void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if(e.PropertyName == "FooProp") OnPropertyChanged("IsButtonEnabled");
		}
		public bool IsButtonEnabled
		{
			get
			{
			  return MyList.Any(x=> x.FooProp!=null);
		    }
		}
	}
