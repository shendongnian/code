	public class StopBlock : INotifyPropertyChanged
	{
		private string header = "Other Stop";
		public string Header
		{
			get { return header; }
			set
			{
				if (header != value)
				{
					header = value;
					NotifyPropertyChanged("Header");
				}
			}
		}
		private readonly ObservableCollection<Departure> departures = new ObservableCollection<Departure>();
		public ObservableCollection<Departure> Departures
		{
			get { return departures; }
		}
		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	public class Departure : INotifyPropertyChanged
	{
		private string line = "88";
		public string Line
		{
			get { return line; }
			set
			{
				if (line != value)
				{
					line = value;
					NotifyPropertyChanged("Line");
				}
			}
		}
		private string name = "Nils Erikson Term";
		public string Name
		{
			get { return name; }
			set
			{
				if (name != value)
				{
					name = value;
					NotifyPropertyChanged("Name");
				}
			}
		}
		private int lorem = 5;
		public int Lorem
		{
			get { return lorem; }
			set
			{
				if (lorem != value)
				{
					lorem = value;
					NotifyPropertyChanged("Lorem");
				}
			}
		}
		private int ipsum = 15;
		public int Ipsum
		{
			get { return ipsum; }
			set
			{
				if (ipsum != value)
				{
					ipsum = value;
					NotifyPropertyChanged("Ipsum");
				}
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
