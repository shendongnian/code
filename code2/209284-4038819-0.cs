    List<Button> buttons = new List<Button> { firstButton, secondButton };
    
    // Iterate Controls collection
    foreach (Control button in this.Controls)
    {
        if (button.GetType() == typeof(Button)) // Check if the control is a Button.
        {
            Button btn = (Button)button; // Cast the control to Button type.
            btn.Click += new System.EventHandler(this.button_Click); // Add event to button.
        }
    }
    
    // Click event for all Buttons control.
    private void button_Click(Button sender, EventArgs e) 
    {
        ChangeForeColor(sender); // A method that accepts a Button
        // other methods to do...
    }
    
    // Changes the ForeColor of the Button being passed.
    private void ChangeForeColor(Button btn)
    {
        btn.ForeColor = Color.Red;
    }
