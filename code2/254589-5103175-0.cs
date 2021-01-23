    Button[] b = new Button[Count];
    
    for (int i=0; i < Count; i++)
    {
        b[i] = new Button();
        b[i].Name = "btn" + i;
        b[i].Click += OnClick
    }
    private void OnClick(object sender, RoutedEventArgs e)
    {
          // do something
    } 
