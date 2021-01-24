	class DbModel : IModel
	{
		public List<string> Values {get; set;}
		IEnumerable<string> IModel.Values
		{
			get { return Values; }
			set
			{
				Values = ... // now what?
			}
		}
	}
	class ViewModel : IModel
	{
		public ObservableCollection<string> Values {get; set;}
		
		IEnumerable<string> IModel.Values
		{
			get { return Values; }
			set
			{
				Values = ... // now what?
			}
		}
	}
