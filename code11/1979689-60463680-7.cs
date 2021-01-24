    class ViewModel
    {
      public ViewModel()
      {
        this.Persons = new ObservableCollection<Person>()
        {
          new Person("Derek", "Zoolander"),
          new Person("Tony", "Montana"),
          new Person("John", "Wick"),
          new Person("The", "Dude"),
          new Person("James", "Bond"),
          new Person("Walter", "White")
        };
      }
    
      private void FilterData(string filterPredicate)
      {
        CollectionViewSource.GetDefaultView(this.Persons).Filter =
            item => (item as Person).FirstName.StartsWith(filterPredicate, StringComparison.OrdinalIgnoreCase);
      }
    
      private string searchPredicate;   
      public string SearchPredicate
      {
        get => this.searchFilter;
        set 
        { 
          this.searchPredicate = value;
          FilterData(value);
        }
      }
    
      public ObservableCollection<Person> Persons { get; set; }
    }
