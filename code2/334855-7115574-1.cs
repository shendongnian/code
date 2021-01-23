    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "test";
        
        //Store it in your session...seems like a weird thing to do given how your page should be stateless, so I would think about what you are
        //trying to do a bit more carefully.  You don't want to call an event handler such as test below from another page in your asp.net app.
        this.TestEvent += new EventHandler(test);
        Session["Invoker"] = this.TestEvent;
    }
    void test(object o, EventArgs e)
    {
        this.Page.Title = "testEvent";
    }
    public event EventHandler TestEvent;
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["Invoker"] != null)
        {
            EventHandler ev = (EventHandler)Session["Invoker"];
            ev(null, EventArgs.Empty);
        }
    }
