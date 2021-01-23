        public ObservableCollection<TabViewModel> Pages { get; set; }
		private TabViewModel currentPage;
		
        public TabViewModel CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
		
		public void AddPage()
		{
		    var page = new TabViewModel();
		    this.Pages.Add(page);
			this.CurrentPage = page;
		}
