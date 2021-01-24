    public class ViewModel {
        private ObserveableCollection<MainContacts> contactList { get; set; }
        public ObserveableCollection<MainContacts> ContactList {
            get {
                return new ObservableCollection<MainContacts>(contactList
                    .Where(yourFilteringFunc)
                    .OrderBy(yourOrderingFunc));
            }
            set {
                contactsList = value;
                OnPropertyChanged();
            }
        }
        //...
    }
