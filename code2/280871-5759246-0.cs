    Dictionary<GridKey, Button> _buttons = new Dictionary<GridKey, Button>();
    
    OnChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
       // snip
       _dict.Add(new GridKey(row, column), button);
    }
