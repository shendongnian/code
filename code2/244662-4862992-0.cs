        public class DataLayer
        {
            public ObservableCollection<ContactModel> GetContacts()
            {
                var tList = new ObservableCollection<ContactModel>();
    
                //load from db into tList
    
                return tList;
            }
        }
    
        public class ContactModel
        {
            public int ContactListID { get; set; }
            public string ContactListName { get; set; }
            public ObservableCollection<AggregatedLabelModel> AggLabels { get; set; }
        }
    
        public class ContactsViewModel
        {
            public ObservableCollection<ContactModel> ListOfContacts;
    
            public ContactsViewModel()
            {
                var dl = new DataLayer();
                ListOfContacts = dl.GetContacts();
            }
        }
