    class MainViewModel : INotifyPropertyChanged
    {
      public MainViewModel()
      {
        this.Pages = new ObservableCollection<IPage>() {new PageA() {Title = "Page A"}, new PageB() {Title = "Page B"}};
        // Show startup page
        this.SelectedPage = this.Pages.First();
      }
    
      // Define the Execute and CanExecute delegates for the command
      // and pass to constructor
      public ICommand SelectPageFromIndexCommand => new SelectPageCommand(
        param => this.SelectedPage = this.Pages.ElementAt(int.Parse(param as string)),
        param => int.TryParse(param as string, out int index) && index < this.Pages.Count);
    
      private IPage selectedPage;    
      public IPage SelectedPage
      {
        get => this.selectedPage;
        set
        {
          if (object.Equals(value, this.selectedPage))
          {
            return;
          }
    
          this.selectedPage = value;
          OnPropertyChanged();
        }
      }
    
      private ObservableCollection<IPage> pages;    
      public ObservableCollection<IPage> Pages
      {
        get => this.pages;
        set
        {
          if (object.Equals(value, this.pages))
          {
            return;
          }
    
          this.pages = value;
          OnPropertyChanged();
        }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;    
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
