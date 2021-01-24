    using GalaSoft.MvvmLight.CommandWpf;
    using System.Collections.ObjectModel;
    namespace wpf_99
    {
    public class MainWindowViewModel : BaseViewModel
    {
        private RelayCommand<Person> deletePersonCommand;
        public RelayCommand<Person> DeletePersonCommand
        {
            get
            {
                return deletePersonCommand
                ?? (deletePersonCommand = new RelayCommand<Person>(
                  (person) =>
                  {
                      People.Remove(person);
                  }
                 ));
            }
        }
        private ObservableCollection<Person> people = new ObservableCollection<Person>();
        public ObservableCollection<Person> People
        {
            get { return people; }
            set { people = value; }
        }
        public MainWindowViewModel()
        {
            People.Add(new Person { FirstName = "Chesney", LastName = "Brown" });
            People.Add(new Person { FirstName = "Gary", LastName = "Windass" });
            People.Add(new Person { FirstName = "Liz", LastName = "McDonald" });
            People.Add(new Person { FirstName = "Carla", LastName = "Connor" });
        }
    }
    }
