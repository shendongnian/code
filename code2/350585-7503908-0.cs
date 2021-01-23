    // Declare your enum:
    private enum Colors { Yellow, Default }
    private Colors ActualColor = Colors.Default;
    // Write your custom event handler:
    private void myEventHandler(object sender, EventArgs e)
    {
        if (ActualColor == Colors.Default)
        {
            // Apply yellow to buttons
            ActualColor = Colors.Yellow;
        }
        else
        {
            // Apply default
            ActualColor = Colors.Default;
        }            
    }
