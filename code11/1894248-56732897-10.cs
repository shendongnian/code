    class MainViewModel
    {
        public MainViewModel()
        {
          // The ComboBox's items source
          // that holds the page view model display names
          this.PageNames= new ObservableCollection<string>() {"First Page", "Second Page"};
          // The Dictionary to get the page view model name 
          // that maps to a page display name
          this.PageViewModelNameMap = new Dictionary<string, string>()
          {
             {"First Page", nameof(FirstViewModel)},
             {"Second Page", nameof(SecondViewModel)}
          };
          // The Dictionary that stores all page view models 
          // that can be retrieved by the page view model type name
          this.PageViewModels = new Dictionary<string, IPageViewModel>()
          {
             {nameof(FirstViewModel), new FirstViewModel()},
             {nameof(SecondViewModel), new SecondViewModel()}
          };
          this.CurrentPageViewModel = this.PageViewModels[nameof(FirstViewModel)];
          this.PageNavigationParameter = string.Empty;
        }
    
        // You can use this method as execute handler 
        // for your NavigateToPage command too
        private void NavigateToPage(object parameter)
        {
          if (!(parameter is string pageName))
          {
            return;
          }
          if (this.PageViewModelNameMap.TryGetValue(pageName, out string pageViewModelName)
          {
            if (this.PageViewModels.TryGetValue(pageViewModelName, out IPageViewModel pageViewModel)
            {
              pageViewModel.PageNavigationParameter = this.PageNavigationParameter;
              this CurrentPageViewModel = pageViewModel;
            }
          }
        }
    
        private bool CanExecuteNavigation(object parameter) => parameter is string destinationPageName && this.PageViewModelNameMap.Contains(destinationPageName);
    
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
    
        private string pageNavigationParameter;   
        public string PageNavigationParameter
        {
          get => this.pageNavigationParameter;
          set 
          { 
            this.pageNavigationParameter= value; 
            OnPropertyChanged();
          }
        }
    
        private Dictionary<string, ViewModelBase> pageViewModels;   
        public Dictionary<string, ViewModelBase> PageViewModels
        {
          get => this.pageViewModels;
          set 
          { 
            this.pageViewModels = value; 
            OnPropertyChanged();
          }
        }
    
        private Dictionary<string, string> pageViewModelNameMap;   
        public Dictionary<string, string> PageViewModelNameMap
        {
          get => this.pageViewModelNameMap;
          set 
          { 
            this.pageViewModelNameMap = value; 
            OnPropertyChanged();
          }
        }
    
        private IPageViewModel currentPageViewModel;   
        public IPageViewModel CurrentPageViewModel 
        {
          get => this.currentPageViewModel;
          set 
          { 
            this.currentPageViewModel= value; 
            OnPropertyChanged();
           }
         }
      }
