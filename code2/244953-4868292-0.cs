    public class MyViewModel
    {
        public ObservableCollection<ContactListModel> ContactLists{get;set;}
    
        public MyViewModel()
        {
            var data = new ContactListDataAccess();
            ContactLists = data.GetContacts();
    
        }
    }
