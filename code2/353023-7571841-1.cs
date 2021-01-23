    private void TextBox_SizeChanged(object sender, SizeChangedEventArgs e) 
    {
        Size n = e.NewSize;
        Size p = e.PreviousSize;
        double l = n.Width / p.Width;
        if (l!=double.PositiveInfinity)
        {
            textbox1.FontSize = textbox1.FontSize * l;
        }
    }
