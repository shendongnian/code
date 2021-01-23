    private void button1_Click(object sender, EventArgs e)
    {
        List<Button> buttons = new List<Button>();
        for (int i = 0; i < 10; i++)
        {
            Button newButton = new Button();
            buttons.Add(newButton);
            this.Controls.Add(newButton);   
        }
    }
