    public MainViewModel() 
            { 
                _dispatcherTimer = new System.Threading.Timer.Timer(DispatcherTimer_Tick,null,3000,3000); 
                _dispatcher= Dispatcher.CurrentDispatcher;
            } 
     
      `private void DispatcherTimer_Tick(object sender)
      {
            Account.Ping = _service.Ping(Account); 
            //Refresh data in dictionary 
            _freshUsers = _service.LoadUsers(Account); 
            _users.Clear(); 
            SelectedUsersIndex = 1; 
     
            foreach (var freshUser in _freshUsers) 
            { 
                _users.Add(freshUser); 
            } 
     		
            for(int i=0;i<Account.Ping.Rp; i++)
            {
            //check if you have new messanges 
                if (Account.Ping.Rp > 0) 
            	    { 
    	        Rp message = _service.LoadRp(Account); 
    		_messages.Add(message);
            	    } 
    	}
    	    _dispatcher.BeginInvoke(()=>{OnPropertyChanged("Messages");});
    	}
