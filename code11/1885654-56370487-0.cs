		private ObservableCollection<SomeBaseClass> _MyItems;
		public ObservableCollection<SomeBaseClass> MyItems
		{
			get { return this._MyItems; }
			set
			{
				if (this._MyItems != value)
				{
					this._MyItems = value;
					RaisePropertyChanged(() => this.MyItems);
				}
			}
		}
