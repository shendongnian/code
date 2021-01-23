    class HelloWorldViewModel : ViewModelBase {
    
      public HelloWorldViewModel() {
        this.DisplayMessageCommand = new RelayCommand( this.DisplayMessage );
        }
       
    
      public RelayCommand DisplayMessageCommand { get; private set; }
    
      public void DisplayMessage() {
        //TODO: Do code here to display your message to the user
        }
      }
