    //Public property
    		public ICommand MyCommand { get; set; }
    
    //In the constructor 
            MyCommand = new RelayCommand(DoSometing);
    
    //Private method to handle lost focus
           private void DoSometing(){
              //Do someting
           }
