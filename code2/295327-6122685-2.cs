    public class RightViewModel : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Change("Name");
            }
        }
		private bool _hasRight;
		public bool HasRight
		{
			get { return _hasRight; }
			set
			{
				_hasRight = value;
				Change("HasRight");
			}
		}
		public void Change(string strPropertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(strPropertyName));
		}
		public event PropertyChangedEventHandler PropertyChanged;
    }
