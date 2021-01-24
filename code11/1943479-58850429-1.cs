    public class ShellViewModel : Screen
    { 
        public void ShellViewModel()
        {
          this.Input = string.Empty;
          this.People = new ObservableCollection<People>();      
        }
       
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
          if (string.IsNullOrWhiteSpace(this.input) 
            || this.People.Any(person => person.name.Equals(this.Input, StringComparison.OrdinalIgnoreCase))
          {
            return;
          }
          Person newPerson = new Person() {name = this.Input};
          this.People.Add(newPerson);      
       }
    }
