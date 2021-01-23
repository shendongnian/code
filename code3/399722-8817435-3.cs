    // create a collection of accounts, then whenever the button is clicked,
    //create a new account object and add to the collection.
    public partial class Window1 : Window
    {
        private ObservableCollection<Account> AccountList = new ObservableCollection<Account>();
        public Window1()
        {
            InitializeComponent();
            AccountList.Add(new Account{ AccountName = "My Account" });
            this.MyAccounts.ItemsSource = AccountList;
        }
         private void okBtn_Click(object sender, RoutedEventArgs e)
        {
           AccountList.Add(new Account{ AccountName = accountaddTextBox.Text});
        }
    }
