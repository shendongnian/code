    public class MainViewModel : ViewModelBase
    {
      public ObservableCollection<Person> Persons { get; set; }
    
      public MainViewModel()
      {
        Persons = new ObservableCollection<Person>();
        Persons.CollectionChanged += PersonCollectionChanged;
      }
    
      private void PersonCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
      {
        if(e.Action == NotifyCollectionChangedAction.Add)
        {
          foreach(Person person in e.NewItems)
          {
            person.Friend_Add += new EventHandler(Add);
          }
        }
      }
    }
