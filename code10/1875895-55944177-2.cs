	private List<Breed> _myList;
		public List<Breed> MyList
		{
			get { return _myList; }
			set { _myList = value; RaiseOnPropertyChanged(); }
		}
