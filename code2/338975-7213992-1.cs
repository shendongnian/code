    public class Person : INotifyPropertyChanged
    {
      public Person()
      {
         Accounts.Add(new Account { AccountNo = "12345", Amount = 79.50 });
         Accounts.Add(new Account { AccountNo = "23456", Amount = 19.40 });
         Accounts.Add(new Account { AccountNo = "34567", Amount = 5.60 });
         Accounts.Add(new Account { AccountNo = "45678", Amount = 109.14 });
      }
      private string _name;
      public string Name
      {
         get { return _name; }
         set
         {
            if (_name == value)
               return;
            _name = value;
            if (PropertyChanged != null)
               PropertyChanged(this, new PropertyChangedEventArgs("Name"));
         }
      }
      private List<Account> _accounts = new List<Account>();
      public List<Account> Accounts
      {
         get { return _accounts; }
         set
         {
            if (_accounts != value)
            {
               _accounts = value;
               if (PropertyChanged != null)
                  PropertyChanged(this, new PropertyChangedEventArgs("Accounts"));
            }
         }
      }
      public event PropertyChangedEventHandler PropertyChanged;
