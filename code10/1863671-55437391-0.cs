    private void Timer_Tick(object sender, System.EventArgs e)
    {
        if (Background == Brushes.Black)
        {
            Background = Brushes.White;
            Title = "White";
        }
        else
        {
            Background = Brushes.Black;
            Title = "Black";
        }
    }
