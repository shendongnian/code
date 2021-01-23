    private void TextBox_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        try
        {
            if (e.PreviousSize == Size.Parse("0,0")) return;
            if (e.PreviousSize == e.NewSize) return;
    
            if (e.HeightChanged)
            {
                ((TextBox)sender).Width = e.PreviousSize.Width + 20;
            }
        }
    
        finally
        {
            e.Handled = true;
        }
    }
