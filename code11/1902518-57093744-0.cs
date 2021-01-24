    string color = "Black";
    if (System.Windows.SystemParameters.HighContrast)
    {
        System.Windows.Media.Brush brush = System.Windows.SystemColors.WindowTextBrush;
        string s = brush.ToString();
        color = typeof(System.Windows.Media.Brushes).GetProperties()
            .FirstOrDefault(p => p.GetValue(null)?
            .ToString() == s)?
            .Name;
    }
