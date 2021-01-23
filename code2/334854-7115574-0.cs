    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "test";
        
        //Store it in your session...seems like a weird thing to do given how your page should be stateless, so I would think about what you are
        //trying to do a bit more carefully.  You don't want to call an event handler such as test below from another page in your asp.net app.
        Dictionary<string, EventHandler> myEvents = null;
        if (Session["Invokers"] == null)
        {
            myEvents = new Dictionary<string, EventHandler>();
            Session["Invokers"] = myEvents;
        }
        else
        {
            myEvents = Session["Invokers"] as Dictionary<string, EventHandler>;
        }
        //If the event handler key is not in there then add it
        if (myEvents.ContainsKey("buttonClickOnPageDefault") == false)
        {
            //Subscribe to event (i.e. add your method to the invokation list
            this.TestEvent += new EventHandler(test);
            myEvents.Add("buttonClickOnPageDefault", this.TestEvent);
        }
        else
        {
            //if it does contain this key then you may already be subscribed to event, so unsubscribe in case and then resubscribe...you could
            //probably do this more elegantly by looking at the vales in the GetInvokationList method on the eventHandler
            //Wire up the event
            this.TestEvent -= new EventHandler(test);
            this.TestEvent += new EventHandler(test);
        }
        //Resave the dictionary.
        Session["Invokers"] = myEvents;
    }
    void test(object o, EventArgs e)
    {
        this.Page.Title = "testEvent";
    }
    public event EventHandler TestEvent;
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["Invokers"] != null)
        {
            Dictionary<string, EventHandler> myEvents = (Dictionary<string, EventHandler>)Session["Invokers"];
            if (myEvents.ContainsKey("buttonClickOnPageDefault"))
            {
                EventHandler ev = myEvents["buttonClickOnPageDefault"];
                ev(null, EventArgs.Empty);
            }
        }
    }
