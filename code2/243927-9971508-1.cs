    public partial class MainPage : PhoneApplicationPage
    {
    // Constructor
    public MainPage()
    {
    InitializeComponent();
    Contacts objContacts = new Contacts();
    objContacts.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(objContacts_SearchCompleted);
    objContacts.SearchAsync(string.Empty, FilterKind.None, null);
    }
    void objContacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
    {
    var ContactsData = from m in e.Results
    select new MyContacts
    {
    DisplayName = m.DisplayName,
    PhoneNumber = m.PhoneNumbers.FirstOrDefault()
    };
    var MyContactsLst = from contact in ContactsData
    group contact by contact.DisplayName into c
    orderby c.Key
    select new Group<MyContacts>(c.Key, c);
    longlist1.ItemsSource = ContactsData;
    }
    }
    public class MyContacts
    {
    public string DisplayName { get; set; }
    public ContactPhoneNumber PhoneNumber { get; set; }
    }
