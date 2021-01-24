    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    namespace TestUWP
    {
        public class Account : INotifyPropertyChanged
    	{
    		private string _accountName;
    		private decimal _amount;
    
    		public string AccountName
    		{
    			get => _accountName;
    			set
    			{
    				_accountName = value;
    				OnPropertyChanged();
    			}
    		}
    
    		public decimal Amount
    		{
    			get => _amount;
    			set
    			{
    				_amount = value;
    				OnPropertyChanged();
    			}
    		}
    
    
    		public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
