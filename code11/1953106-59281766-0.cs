    public class ViewModelA : ViewModelBase
    {
        public void SearchCommandMethod()
        {
            MessengerInstance.Send<NotificationMessage>(new NotificationMessage("notification message"));
        }
    }
     
    Jesse Liberty of Microsoft has a great concrete walk through on how to make use of the messaging within MVVM Light. The premise is to create a class which will act as your message type, subscribe, then publish.
    
    public class GoToPageMessage
    {
       public string PageName { get; set; }
    }
    This will essentially send the message based on the above type/class...
    
        private object GoToPage2()
        {
           var msg = new GoToPageMessage() { PageName = "Page2" };
           Messenger.Default.Send<GoToPageMessage>( msg );
           return null;
        }
    
    Now you can register for the given message type, which is the same class defined above and provide the method which will get called when the message is received, in this instance ReceiveMessage.
    
        Messenger.Default.Register<GoToPageMessage>
        ( 
             this, 
             ( action ) => ReceiveMessage( action ) 
        );
        
        private object ReceiveMessage( GoToPageMessage action )
        {
           StringBuilder sb = new StringBuilder( "/Views/" );
           sb.Append( action.PageName );
           sb.Append( ".xaml" );
           NavigationService.Navigate( 
              new System.Uri( sb.ToString(), 
                    System.UriKind.Relative ) );
           return null;
        }
