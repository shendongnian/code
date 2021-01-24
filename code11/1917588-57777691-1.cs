    void AddAButton(Label newLabel)
    {
        Button newButton = new Button();
        buttons.Add(newButton);
        newButton.Left = left + 100;
        newButton.Top = top;
        newButton.Text = "DELETE";
        panel1.Controls.Add(newButton);
        top += 40;
        newButton.Click += (s, e) => {
           panel1.Controls.Remove(newLabel);
           panel1.Controls.Remove(newButton);
           newLabel.Dispose();
           newButton.Dispose();
        }
    }
