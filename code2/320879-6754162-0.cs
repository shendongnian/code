    //do the same lenght as the for loop bellow:
    string[] buttonNames = { "button1", "button2", "button3", "button4", "button5" };
    
    for (int i = 0; i < buttonNames.Lenght; i++)
    {
      Button newButton = new Button();
      newButton.Name = "button" + i.ToString();
      newButton.Text = buttonNames[i]; //each button will now get its own name from array
      newButton.Location = new Point(32, i * 32);
      newbutton.Size = new Size(25,100); //maybe you can set different sizes too (especially for X axes)
      newButton.Click += new EventHandler(buttons_Click);
      this.Controls.Add(newButton);
    }
    
    
    private void buttons_Click(object sender, EventArgs e)
    {
      Button btn = sender as Button
      MessageBox.Show("You clicked button: " + btn.Text + ".");
    }
