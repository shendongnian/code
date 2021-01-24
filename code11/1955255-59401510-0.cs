    // Safe casting to Button instance.
    Button button = sender as Button;
    // Make sure the cast didn't return a null value
    if(button == null) return;
    // Set enable to true
    button.IsEnabled = true; // You can also use button.IsEnabled = !button.IsEnabled 
