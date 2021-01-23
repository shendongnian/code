    class HelloWorldViewModel : ViewModelBase {
    
      public HelloWorldViewModel() {
        this.DisplayMessageCommand = new RelayCommand( this.DisplayMessage, CanDisplayMessage );
        // Create a timer to go off once a minute to call RaiseCanExecuteChanged
        _timer = new DispatchTimer();
        _timer = dispatcherTimer.Tick += OnTimerTick;
        _timer.Interval = new Timespan( 0, 1, 0 );
        _timer.Start();
        }
       
      private DispatchTimer _timer;
      
      private void OnTimerTick( object sender, EventArgs e ) {
        this.DisplayMessageCommand.RaiseCanExecuteChanged();
        }
      public RelayCommand DisplayMessageCommand { get; private set; }
      public bool CanDisplayMessage() {
        return DateTime.Now.Minute % 2 == 0;
        }
    
      public void DisplayMessage() {
        //TODO: Do code here to display your message to the user
        }
      }
