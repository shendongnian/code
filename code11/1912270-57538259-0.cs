     public void AddButton(Panel container)
     {
        const int maxAllowedButtons = 6;
        int existingButtonCount = container.Controls.OfType<Button>().Count();
        if (existingButtonCount < maxAllowedButtons)
        {
            Button newButton = new Button();
            newButton.Left = newButton.Width * existingButtonCount; // set left position so buttons do not draw on top of each other
            container.Controls.Add(newButton);
         }
     }
