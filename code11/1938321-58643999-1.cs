    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["counter"] != null)
            {
                int counter = Convert.ToInt32(ViewState["counter"]);
                
                ViewState["counter"] = counter++;
            }        
            else
            {
                int count = 1;
                ViewState["counter"] = count;
            }   
            var myThing = new MyThing();
            myThing.EventHappens += EventHappensCompleted;
        }
        catch (Exception err)
        {
            Response.Write("ERROR");
        }
    }
