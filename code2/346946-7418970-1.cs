    //in code behind constructor, but should actually be in a ViewModel
    var people = new ObservableCollection<Person>
                            {
                                  new Person(false, "test1"),
                                  new Person(true, "test2"),
                                  new Person(true, "test3"),
                             };
    lst.ItemsSource = people;
    //Person class for completeness
    public class Person
    {
        public Person(bool isSelected, string name)
        {
            IsSelected = isSelected;
            Name = name;
        }
        public bool IsSelected { get; set; }
        public string Name { get; set; }
    }
