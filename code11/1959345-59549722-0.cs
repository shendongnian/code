	public class MainViewModel : ViewModelBase
	{
		private object _CurrentPage;
		public object CurrentPage
		{
			get { return this._CurrentPage; }
			set
			{
				if (this._CurrentPage != value)
				{
					this._CurrentPage = value;
					RaisePropertyChanged(() => this.CurrentPage); // <--- important that you do this
				}
			}
		}
