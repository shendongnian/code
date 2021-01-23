	public class Employee : INotifyPropertyChanged
	{
		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; 
			NotifyPropertyChanged("Name");}
		}
		private Occupation occupation;
		public Occupation Occupation
		{
			get { return occupation; }
			set { occupation = value; 
			NotifyPropertyChanged("Occupation");}
		}
		public Employee(string name, Occupation occupation)
		{
			this.name = name;
			this.occupation = occupation;
		}
		
		#region INotifyPropertyChanged Members
		...
		#endregion
	}
	
	public class Occupation : INotifyPropertyChanged
	{
		private string title;
		public string Title
		{
			get { return title; }
			set { title = value; 
			NotifyPropertyChanged("Title");}
		}
		
		public Occupation(string title)
		{ Title = title; }
		
		#region INotifyPropertyChanged Members
		...
		#endregion
	}
