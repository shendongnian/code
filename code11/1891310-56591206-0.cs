    Textbox newTextBox = new Textbox();
    newTextBox.Text = "Search google or type URL";
    
    newTextBox.GotFocus += GotFocus.EventHandle(RemoveText);
    newTextBox.LostFocus += LostFocus.EventHandle(AddText);
    
    public void RemoveText(object sender, EventArgs e)
    {
        if (newTextBox.Text == "Search google or type URL") 
        {
         newTextBox.Text = "";
        }
    }
    
    public void AddText(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(newTextBox.Text))
            newTextBox.Text = "Search google or type URL";
    }
