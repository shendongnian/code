    public class Stuff
    {
        // Public Event to allow other classes to subscribe to.
        public event EventHandler GetHtmlDone;
    
        public void GetHTML(string url)
        {
            //Do stuff
    
            // Raise Event, which triggers all method subscribed to it!
            this.GetHtmlDone(this, new EventArgs());
        }
    }
    
    public class Other
    {
        public Other()
        {
            Stuff stuff = new Stuff();
    
            // Subscribe to the event.
            stuff.GetHtmlDone += new EventHandler(OnGetHtmlDone);
    
            // Execute
            stuff.GetHTML("someUrl");
        }
    
        void OnGetHtmlDone(object sender, EventArgs e)
        {
            //Do stuff with the result since it's done
        }
    }
