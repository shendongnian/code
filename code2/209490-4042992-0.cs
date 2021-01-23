    public class MyCustomControl : UserControl {
        // Custom routed event
        public static readonly RoutedEvent ButtonClickEvent = EventManager.RegisterRoutedEvent(
            "ButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MyCustomControl));
    
    	// Custom CLR event associated to the routed event
        public event RoutedEventHandler ButtonClick {
            add { AddHandler(ButtonClickEvent, value); } 
            remove { RemoveHandler(ButtonClickEvent, value); }
        }
    	
    	// Constructor. Subscribe to the event and route it !
    	public MyCustomControl() {
    		theButton.Click += (s, e) => {
    		    RaiseButtonClickEvent(e);
    		};
    	}
    
    	// Router for the button click event
        private void RaiseButtonClickEvent(RoutedEventArgs args) {
    	    // you need to find a way to copy args to newArgs (I never tried to do this, google it)
    	    RoutedEventArgs newArgs = new RoutedEventArgs(MyCustomControl.ButtonClickEvent);
            RaiseEvent(newArgs);
        }
    }
