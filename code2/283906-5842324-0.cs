    // code in form1 might look something like
    
    public void SubscribeToEvents()
    {
       // get Form2 reference
       var form2 = GetForm2Reference();
       form2.Button.Click += ButtonOnForm2EventHandler;
    }
    
    public void ButtonOnForm2EventHandler(object sender, EventHandlerArgs e)
    {
       // some code
    }
