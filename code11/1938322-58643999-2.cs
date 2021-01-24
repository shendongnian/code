    protected void EventHappensCompleted(object o, CustomEventArgs e)
    {
        if (ViewState["counter"] != null)
        {
            var count = Convert.ToInt32(ViewState["counter"]);
            for (int i = 0; i < count; i++)
            {
                Response.Write("EventHappensCompleted");
            }
         }
    }
