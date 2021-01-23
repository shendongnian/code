    public ctor() // Method where you want to hook the event, can be constructor or any thing else
    {
        //Hook to event
        obj.ChangesMade += Changes_Made; 
        // Here obj is the object of type in which you have okButton_Click 
        // and ChangesMade event declaration
    }
    public void Changes_Made()
    {
         //yay. Changes made. update grid
    }
    
    //declare event
    public event EventHandler ChangesMade();
    protected void okButton_Click(object sender, EventArgs e)
    {
        //...
        //save data
        //...
        //raise event
        if(ChangesMade != null)
            ChangesMade(this, new EventArgs());
    }
