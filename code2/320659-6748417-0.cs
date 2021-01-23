    using System.Collections.ObjectModel;
    using GalaSoft.MvvmLight;
    
    namespace XXXX.ViewModel
    {
        public class MainViewModel : ViewModelBase
        {
            private ObservableCollection<Person> _people;
            public ObservableCollection<Person> People
            {
                get { return _people; }
                set
                {
                    if (value == _people) return;
                    _people = value;
                    RaisePropertyChanged("People");
                    RaisePropertyChanged("HierarchyPeople");
                }
            }
    
            public HierarchyPeople HierarchyPeople
            {
                get
                {
                    return
    
                        //=====> Change _people to new format
                        (HierarchyPeople)_people;
                }
                set
                {
                    if (value == (HierarchyPeople)_people) return;
                    _people = value;
                    RaisePropertyChanged("People");
                    RaisePropertyChanged("HierarchyPeople");
                }
            }
        }
    
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Gategory Categories { get; set; }
        }
    
        public class Gategory
        {
        }
    
        class HierarchyPeople : ObservableCollection<Person>
        {
        }
    }
