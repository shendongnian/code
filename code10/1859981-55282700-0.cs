    private static readonly BitmapImage gcb = new BitmapImage(new Uri("pack://application:,,,/Images/check.png"));
    private static readonly BitmapImage rxb = new BitmapImage(new Uri("pack://application:,,,/Images/redx.png"));
    private void UpdateLBUImage(int val)
    {
        if (val == 1)
        {
            StatusImage.Source = gcb;
        }
        else
        {
            StatusImage.Source = rxb;
        }
    }
