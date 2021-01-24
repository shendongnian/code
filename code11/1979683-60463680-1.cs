    class ViewModel
    {
      public ViewModel()
      {
        this.Persons = new ObservableCollection<Person>()
        {
          new Person("Derek", "Zoolander"),
          new Person("Tony", "Montana"),
          new Person("John", "Wick"),
          new Person("The", "Dude")
        };
      }
    
      private void FilterData(string filterPredicate)
      {
        CollectionViewSource.GetDefaultView(this.Persons).Filter =
            item => (item as Person).FirstName.StartsWith(filterPredicate, StringComparison.OrdinalIgnoreCase);
      }
    
      private string searchFilter;   
      public string SearchFilter
      {
        get => this.searchFilter;
        set 
        { 
          this.searchFilter = value;
          FilterData(value);
        }
      }
    
      public ObservableCollection<Person> Persons { get; set; }
    }
