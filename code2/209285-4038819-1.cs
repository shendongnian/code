    List<Button> buttons = new List<Button> { firstButton, secondButton };
    
    // Iterate through the collection of Controls, or you can use your List of buttons above.
    foreach (Control button in this.Controls)
    {
        if (button.GetType() == typeof(Button)) // Check if the control is a Button.
        {
            Button btn = (Button)button; // Cast the control to Button.
            btn.Click += new System.EventHandler(this.button_Click); // Add event to button.
        }
    }
    
    // Click event for all Buttons control.
    private void button_Click(Button sender, EventArgs e) 
    {
        ChangeForeColor(sender); // A method that accepts a Button
        // other methods to do...
        // you can also check here what button is being clicked 
        // and what action to do for that particular button.
        // Ex:
        //
        // switch(sender.Name)
        // {
        //     case "firstButton":
        //         sender.ForeColor = Color.Blue;
        //         break;
        //     case "secondButton ":
        //         sender.Text = "I'm Button 2";
        //         break;
        // }
    }
    
    // Changes the ForeColor of the Button being passed.
    private void ChangeForeColor(Button btn)
    {
        btn.ForeColor = Color.Red;
    }
