    class ViewModel : INotifyPropertyChanged
    {
      public ViewModel()
      {
        this.Persons = new ObservableCollection<Person>()
        {
          new Person("Derek", "Zoolander"),
          new Person("Tony", "Montana"),
          new Person("The", "Dude")
        };
      }
    
      public ObservableCollection<Person> Persons { get; set; }
    }   
