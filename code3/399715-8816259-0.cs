    public class AccountListViewModel : INotifyPropertyChanged
    {
        
        ICommand AddAccountCommand {get; set;}
        
        public AccountListViewModel()
        {
            AccountList = new ObservableCollection<string>();
            AddAccountCommand= new RelayCommand(AddAccount);
            //Fill account List saved data
            FillAccountList();
        }
        public AddAccount(object obj)
        {
            AccountList.Add(AccountName); 
            //Call you Model function To Save you lIst to DB or XML or Where you Like
            SaveAccountList()   
        }
            
        public ObservableCollection<string> AccountList 
        { 
                get {return accountList} ; 
                set
                {
                    accountList= value
                    OnPropertyChanged("AccountList");
                } 
        }
        
        public string AccountName 
        { 
                get {return accountName } ; 
                set
                {
                    accountName = value
                    OnPropertyChanged("AccountName");
                } 
        }
        
    }
