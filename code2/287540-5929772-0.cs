    for(int i=0; i<5; i++)
    {
        System.Windows.Controls.Button newBtn = new Button();
    
        newBtn.Content = i.ToString();
        newBtn.Name = "Button" + i.ToString();
        sp.Children.Add(newBtn);
    }
 
