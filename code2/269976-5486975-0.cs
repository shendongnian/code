    using MyNamespace;
    
    private void StackPanel_Initialized(object sender, EventArgs e)
    {
        MyControl newItem = new MyControl();
        // Set any other properties
        StackPanel parent = sender as StackPanel;
        parent.Children.Add(newItem);
    }
