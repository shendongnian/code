    // sample C#
    public void populateButtons()
    {
        int xPos;
        int yPos;
     
        Random ranNum = new Random();
     
        for (int i = 0; i < 50; i++)
        {
            Button foo = new Button();
            Style buttonStyle = Window.Resources["CurvedButton"] as Style;
     
            int sizeValue = ranNum.Next(50);
     
            foo.Width = sizeValue;
            foo.Height = sizeValue;
            foo.Name = "button" + i;
     
            xPos = ranNum.Next(300);
            yPos = ranNum.Next(200);
     
            foo.HorizontalAlignment = HorizontalAlignment.Left;
            foo.VerticalAlignment = VerticalAlignment.Top;
            foo.Margin = new Thickness(xPos, yPos, 0, 0);
     
            foo.Style = buttonStyle;
     
            foo.Click += new RoutedEventHandler(buttonClick);
            LayoutRoot.Children.Add(foo);
       }
    }
     
    private void buttonClick(object sender, EventArgs e)
    {
      //do something or...
      Button clicked = (Button) sender;
      MessageBox.Show("Button's name is: " + clicked.Name);
    }
