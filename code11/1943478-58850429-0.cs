    public class ShellViewModel : Screen
    { 
        private string _input = string.Empty;
        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                NotifyOfPropertyChange(() => Input);
            }
        }       
        private ObservableCollection<Person> people;
        public ObservableCollection<Person> People
        {
            get => people;
            set
            {
                people = value;
                NotifyOfPropertyChange(() => People);
            }
        }
        public void Write()
        {
          if (this.People.Any(person => person.name.Equals(this.Input, StringComparison.OrdinalIgnoreCase))
          {
            return;
          }
          Person newPerson = new Person() {name = this.Input};
          this.People.Add(newPerson);      
       }
    }
