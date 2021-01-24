    void AddAButton(Label newLabel)
    {
        Button newButton = new Button();
        buttons.Add(newButton);
        newButton.Left = left + 100;
        newButton.Top = top;
        newButton.Text = "DELETE";
        panel1.Controls.Add(newButton);
        top += 40;
        // Store the current shopItem in the context (for the lambda)
        var shopItem = shopItems[shopItemNumber]  
        newButton.Click += (s, e) => {
           panel1.Controls.Remove(newLabel);
           panel1.Controls.Remove(newButton);
           newLabel.Dispose();
           newButton.Dispose();
           shopItems.Remove(shopItem);
        }
    }
