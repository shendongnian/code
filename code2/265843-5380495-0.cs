    public class MenuScreen {
        // the common pattern for events is method which can event raise
        // the event-raising methods should have prefix "On-"
        protected internal virtual void OnEntrySelected( EventArgs e ) {
            // delegates are immutable, so variable "handler" will not be changed
            var handler = this.EntrySelected;
            // check for null. null handler can not be raised
            if ( null != handler ) {
                // raise handler
                handler(this, e);
            }
        }
        // the common pattern for event handler are arguments "sender" and "args".
        // the public members should start with upper case
        // the common pattern for events "something happend" is suffix "-ed"
        public event EventHandler EntrySelected;
    }
    
    public class MenuEntry {
        public void Draw(MenuScreen screen, Vector2 position) {
            // ... some code ...
            screen.OnEntrySelected( EventArgs.Empty );
        }
    }
