      private ObservableCollection<Test> filteredItems;
        public ObservableCollection<Test> FilteredItems
        {
            get => filteredItems;
            set
            {
                // Notify property changed
            }
        }
        private List<Test> allItems;
        public List<Test> AllItems
        {
            get => allItems;
            set
            {
                // Notify property changed
            }
        }
        private string searchTerm;
        public string SearchTerm
        {
            get => searchTerm;
            set
            {
                // Notify property changed
                SearchCommand.Execute(searchTerm);
            }
        }
        public Command SearchCommand
        {
            get
            {
                return new Command<string>((searchString) =>
                {
                    FilteredItems = new ObservableCollection<Test>(AllItems.Where(o => o.itemText.ToLower().Contains(searchString.ToLower())));
                });
            }
        }
