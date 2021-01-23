    public class PeopleTreeItem
    {
        public string Header;
        public ObservableCollection<object> Items;
        public PeopleTreeItem(string header, IEnumerable<object> items)
        {
            Header = header;
            Items = new ObservableCollection<object>() { items };
        }
    }
    public class SomeViewModel : ViewModelBase
    {
        private ObservableCollection<Person> _peopleList;
        private PeopleTreeItem _peopleTree;
        public ObservableCollection<Person> PeopleList
        {
            get { return _people; }
        }
        public PeopleTreeItem PeopleTree
        {
            get 
            { 
                if (_peopleTree == null)
                {
                    _peopleTree = new PeopleTreeItem();
                    _peopleTree.Add(new PeopleTreeItem("Adults", PeopleList.Where(p => p.Type == "Adult")));
                    _peopleTree.Add(new PeopleTreeItem("Teens", PeopleList.Where(p => p.Type == "Teen")));
                    _peopleTree.Add(new PeopleTreeItem("Children", PeopleList.Where(p => p.Type == "Child")));
                }
                return _people; 
            }
        }
