    public List<string> messages = new List<string>() { "Apple", "Apple Pie", "Apple Jam", "Orange", "Banana" };
    
    public void button_Click(object sender, EventArgs e)
    {
        var foundList = messages.Where(m => m.Contains(textBox.Text)).ToList();        
        Messages.ItemsSource = foundList;
    }
