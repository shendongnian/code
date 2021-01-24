    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    
    namespace TestUWP
    {
    	public class AccountViewModel
    	{
    		public AccountViewModel()
    		{
    			Accounts = new ObservableCollection<Account>
    			{
    				new Account {AccountName = "Account 1", Amount = 1000M},
    				new Account {AccountName = "Account 2", Amount = 2000M},
    				new Account {AccountName = "Account 3", Amount = 3000M},
    			};
    
    			AddAccountCommand = new RelayCommand(AddAccount);
    			EditAccountCommand = new RelayCommand(EditAccount);
    		}
    
    		public ICommand AddAccountCommand { get; }
    		public ICommand EditAccountCommand { get; }
    
    		public ObservableCollection<Account> Accounts { get; }
    
    		private void AddAccount()
    		{
    			Accounts.Add(new Account{AccountName = $"Account {Accounts.Count+1}", Amount = 1000M * (Accounts.Count+1)});
    		}
    
    		private void EditAccount()
    		{
    			Accounts[Accounts.Count - 1].Amount += 200M;
    		}
    	}
    
        public class RelayCommand : ICommand
        {
            private readonly Action _execute;
            private readonly Func<bool> _canExecute;
            public event EventHandler CanExecuteChanged;
    
    		public RelayCommand(Action execute, Func<bool> canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }
    
            public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;
    
            public void Execute(object parameter) => _execute();
    
            public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
