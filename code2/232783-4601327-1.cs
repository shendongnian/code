	public class MyViewModel : INotifyPropertyChanged
	{
		string _text = "Enter text here";
		public string Text
		{
			get { return _text; }
			set 
			{ 
				_text = value;
				// raise property change notification
			}
		}
	
		// implement INPC so the view will know when the view-model has changed
	}
