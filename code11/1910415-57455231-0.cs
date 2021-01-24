    public partial class Page4 : ContentPage
	{
        public APIViewModel LocalAPIViewModel { get; set; }
		public Page4 ()
		{
			InitializeComponent ();
            LocalAPIViewModel = new APIViewModel();           
            listview1.ItemsSource = LocalAPIViewModel.ContactsList;
		}
	}
    public class APIViewModel
    {
        public ObservableCollection<MainContacts> ContactsList { get; set; }
        public APIViewModel()
        {
            loadddata();
        }
        public void loadddata()
        {
            ContactsList = new ObservableCollection<MainContacts>();
            for(int i=0;i<20;i++)
            {
                MainContacts p = new MainContacts();
                p.ID = i;
                p.FirstName = "cherry"+i;
                ContactsList.Add(p);
            }
        }
    }
    public class MainContacts
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
    }
