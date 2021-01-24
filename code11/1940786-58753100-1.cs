    class ViewModel : INotifyPropertyChanged
    {
      public ViewModel()
      {
        this.Persons = new ObservableCollection<Person>()
        {
          new Person("Jim", "Beam"),
          new Person("Tony", "Montana"),
          new Person("The", "Dude")
        };
      }
    
      public ObservableCollection<Person> Persons { get; set; }
    }
    
