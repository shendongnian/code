    private Color backgroundColor;
    
    private void startPlotting()
    {
        backgroundColor = BackColor;
        BackColor = Color.Black;
        // etc..
    }
    
    private void restoreWindow()
    { 
        BackColor = backgroundColor;
    }
