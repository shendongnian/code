    for (int i = 0; i < 5; i++)
    {
      Button newButton = new Button();
      newButton.Name = "button" + i.ToString();
      newButton.Location = new Point(32, i * 32);
      newButton.Click += new EventHandler(button1_Click);
      this.Controls.Add(newButton);
    }
    private void button1_Click(object sender, EventArgs e)
    {
      if (((Button)sender).Name == "button0")
        MessageBox.Show("Button 0");
      else if (((Button)sender).Name == "button1")
        MessageBox.Show("Button 1");
    }
