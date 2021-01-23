    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
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
                    //=====> Change _people to new format
                    return new HierarchyPeople(_people);
                }
            }
        }
    
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Gategory Gategory { get; set; }
        }
    
        public class Gategory
        {
        }
    
        public class HierarchyPeople : Dictionary<Gategory, List<Person>>
        {
            public HierarchyPeople(ObservableCollection<Person> people)
            {
                var categories = people.Select(p => p.Gategory).Distinct();
    
                foreach (var cat in categories)
                    this.Add(cat, people.Where(p => p.Gategory == cat).ToList());
            }
        }
    }
