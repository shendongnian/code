    class MainViewModel
    {
        public MainViewModel()
        {
          this.PageNames= new ObservableCollection<string>() {"First Page", "Second Page"};
        }
    
        private void NavigateToPage(string pageName)
        {
          // Execute page navigation
        }
    
        private void OnSelectedPageChanged(string selectedPageName)
        {
          NavigateToPage(selectedPageName);
        }
    
        private ObservableCollection<string> pageNames;   
        public ObservableCollection<string> PageNames
        {
          get => this.pageNames;
          set 
          { 
            this.pageNames = value; 
            OnPropertyChanged();
          }
        }
    
        private string selectedPageName;   
        public string SelectedPageName
        {
          get => this.selectedPageName;
          set 
          { 
            this.selectedPageName = value; 
            OnPropertyChanged();
            OnSelectedPageChanged(value);
           }
         }
      }
