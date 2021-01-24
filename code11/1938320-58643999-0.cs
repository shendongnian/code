    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            var myThing = new MyThing();
            myThing.EventHappens += EventHappensCompleted;
        }
        catch (Exception err)
        {
            Response.Write("ERROR");
        }
    }
